using Haskap.LayeredArchitecture.BusinessLogic.Services;
using Haskap.LayeredArchitecture.Core.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Services;
using Microsoft.EntityFrameworkCore;
using WorkflowEngine.BusinessLogic.Specifications;
using WorkflowEngine.DataAccess.DbContexts;

namespace WorkflowEngine.BusinessLogic.Services
{
    public class WorkflowEngineService : BaseService, IWorkflowEngineService
    {
        private readonly EfCoreOracleWorkflowEngineDbContext workflowEngineDbContext;

        public WorkflowEngineService(EfCoreOracleWorkflowEngineDbContext workflowEngineDbContext)
        {
            this.workflowEngineDbContext = workflowEngineDbContext;
        }

        public State GetRequestCurrentState(Guid requestId)
        {
            return this.workflowEngineDbContext.Request
                .Include(x => x.CurrentState)
                .Where(x => x.Id == requestId)
                .Select(x => x.CurrentState)
                .Single();
        }

        public bool IsProcessAdmin(Guid processId, Guid userId)
        {
            return this.workflowEngineDbContext.ProcessAdmin
                .Any(new ProcessAdminSpecification(processId, userId));
        }

        public State GetRequestNextState(Guid requestId, string actionCodeName, Guid userId)
        {
            var request = this.workflowEngineDbContext.Request
                .Find(requestId);
            State nextState;
            var isProcessAdmin = IsProcessAdmin(request.ProcessId.Value, userId);
            if (isProcessAdmin == true)
            {
                var path = this.workflowEngineDbContext.Path
                    .Include(x => x.Action)
                    .Include(x => x.ToState)
                    .Single(x => x.FromStateId == request.CurrentStateId && x.Action.CodeName == actionCodeName);
                nextState = path.ToState;
            }
            else
            {
                var paths = this.workflowEngineDbContext.Path
                    .Include(x => x.Action)
                    .Include(x => x.ToState)
                    .Where(x => x.FromStateId == request.CurrentStateId)
                    .ToList();
                var pathIds = paths.Select(x => x.Id);
                var authorizedPathUsers = this.workflowEngineDbContext.PathUser
                    .Where(x => pathIds.Contains(x.PathId) && x.UserId == userId)
                    .ToList();
                var authorizedPathIds = authorizedPathUsers.Select(x => x.PathId);
                var path = paths.Where(x => authorizedPathIds.Contains(x.Id) && x.Action.CodeName == actionCodeName).SingleOrDefault();

                if (path == null)
                {
                    throw new InvalidOperationException();
                }

                nextState = path.ToState;
            }

            return nextState;
        }

        public State GetStartState(Guid processId)
        {
            return this.workflowEngineDbContext.State
                .Single(new StartStateSpecification(processId));
        }

        public Progress SaveProgress(Guid requestId, string actionCodeName, Guid userId, string message, RequestData data)
        {
            var date = DateTime.Now;
            var nextState = GetRequestNextState(requestId, actionCodeName, userId);
            var progress = new Progress
            {
                Message = message,
                Path = nextState.FromPaths.FirstOrDefault(x => x.Action.CodeName == actionCodeName),
                ProgressDate = date,
                ProgressedById = userId,
                RequestId = requestId
            };
            this.workflowEngineDbContext.Progress.Add(progress);

            var request = this.workflowEngineDbContext.Request
                .Find(requestId);
            request.CurrentStateId = nextState.Id;
            request.Data = data;
            this.workflowEngineDbContext.Request.Update(request);

            this.workflowEngineDbContext.SaveChanges();

            return progress;
        }

        public IList<Guid?> GetProgressedUserIdsForRecursiveState(Guid requestId)
        {
            var userIds = workflowEngineDbContext.Progress
                .Include(progress => progress.Path).ThenInclude(path => path.Action)
                .Include(progress => progress.Request)
                .Where(x => x.RequestId == requestId && x.Path.FromStateId == x.Request.CurrentStateId && x.Path.ToStateId == x.Request.CurrentStateId)
                .OrderByDescending(p => p.ProgressDate)
                .TakeWhile(x => x.Path.Action.ActionType == ActionType.RestartAction || true)
                .Select(x => x.ProgressedById)
                .ToList();

            return userIds;
        }

        public IList<Path> GetPossibleRequestPaths(Guid requestId, Guid userId)
        {
            var request = this.workflowEngineDbContext.Request
                .Include(r => r.CurrentState)
                .Single(x => x.Id == requestId);

            var paths = this.workflowEngineDbContext.Path
                .Include(x => x.Action).ThenInclude(x => x.ActionType).Include(x => x.ToState).Include(x => x.FromState)
                .Where(x => x.FromStateId == request.CurrentStateId)
                .ToList();

            if (request.CurrentState.StateType == StateType.RecursiveState)
            {
                var userIds = GetProgressedUserIdsForRecursiveState(requestId);
                if (userIds.Contains(userId)) // eger bu userId daha once RecursiveState icin islem yapmissa
                {
                    paths = paths.Where(x => x.Action.ActionType == ActionType.RestartAction || x.ToStateId != request.CurrentStateId).ToList();
                }
            }

            var authorizedPossiblePaths = paths;
            var isProcessAdmin = IsProcessAdmin(request.ProcessId.Value, userId);

            if (isProcessAdmin == false)
            {
                var pathIds = paths.Select(x => x.Id);
                var authorizedPathUsers = this.workflowEngineDbContext.PathUser
                    .Where(x => pathIds.Contains(x.PathId) && x.UserId == userId)
                    .ToList();
                var authorizedPathIds = authorizedPathUsers.Select(x => x.PathId);
                authorizedPossiblePaths = paths.Where(x => authorizedPathIds.Contains(x.Id)).ToList();
            }

            return authorizedPossiblePaths;
        }


    }
}
