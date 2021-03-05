using Haskap.LayeredArchitecture.BusinessLogic.Services;
using Haskap.LayeredArchitecture.Core.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.UnitOfWork;
using WorkflowEngine.Core.Services;
using Microsoft.EntityFrameworkCore;
using WorkflowEngine.BusinessLogic.Specifications;

namespace WorkflowEngine.BusinessLogic.Services
{
    public class WorkflowEngineService : BaseService, IWorkflowEngineService
    {
        private readonly IWorkflowEngineUnitOfWork unitOfWork;

        public WorkflowEngineService(IWorkflowEngineUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public State GetRequestCurrentState(Guid requestId)
        {
            return this.unitOfWork.GetRepository<Request>().Get(x => x.Id == requestId, e => e.Include(x => x.CurrentState)).CurrentState;
        }

        public bool IsProcessAdmin(Guid processId, Guid userId)
        {
            return this.unitOfWork.GetRepository<ProcessAdmin>().Exists(new ProcessAdminSpecification(processId, userId), string.Empty);
        }

        public State GetRequestNextState(Guid requestId, string actionCodeName, Guid userId)
        {
            var request = this.unitOfWork.GetRepository<Request>().GetById(requestId);
            State nextState;
            var isProcessAdmin = IsProcessAdmin(request.ProcessId.Value, userId);
            if (isProcessAdmin == true)
            {
                var path = this.unitOfWork.GetRepository<Path>().Get(x => x.FromStateId == request.CurrentStateId && x.Action.CodeName == actionCodeName, "Action,ToState");
                nextState = path.ToState;
            }
            else
            {
                var paths = this.unitOfWork.GetRepository<Path>().GetMany(x => x.FromStateId == request.CurrentStateId, "Action,ToState");
                var pathIds = paths.Select(x => x.Id);
                var authorizedPathUsers = this.unitOfWork.GetRepository<PathUser>().GetMany(x => pathIds.Contains(x.PathId) && x.UserId == userId, string.Empty);
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
            return this.unitOfWork.GetRepository<State>().Get(new StartStateSpecification(processId), string.Empty);
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
            this.unitOfWork.GetRepository<Progress>().Add(progress);

            var request = this.unitOfWork.GetRepository<Request>().GetById(requestId);
            request.CurrentStateId = nextState.Id;
            request.Data = data;
            this.unitOfWork.GetRepository<Request>().Update(request);

            this.unitOfWork.SaveChanges();

            return progress;
        }

        public IList<Guid?> GetProgressedUserIdsForRecursiveState(Guid requestId)
        {
            var userIds = unitOfWork.GetRepository<Progress>().GetManyWhile(
                whilePredicate: x => x.Path.Action.ActionType == ActionType.RestartAction || true,
                where: x => x.RequestId == requestId && x.Path.FromStateId == x.Request.CurrentStateId && x.Path.ToStateId == x.Request.CurrentStateId,
                include: x => x.Include(progress => progress.Path).ThenInclude(path => path.Action).Include(progress => progress.Request),
                orderBy: x => x.OrderByDescending(p => p.ProgressDate))
                .Select(x => x.ProgressedById)
                .ToList();

            return userIds;
        }

        public IList<Path> GetPossibleRequestPaths(Guid requestId, Guid userId)
        {
            var request = this.unitOfWork.GetRepository<Request>().Get(x => x.Id == requestId, x => x.Include(r => r.CurrentState));
            var paths = this.unitOfWork.GetRepository<Path>().GetMany(
                x => x.FromStateId == request.CurrentStateId,
                e => e.Include(x => x.Action).ThenInclude(x => x.ActionType).Include(x => x.ToState).Include(x => x.FromState));

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
                var authorizedPathUsers = this.unitOfWork.GetRepository<PathUser>().GetMany(x => pathIds.Contains(x.PathId) && x.UserId == userId, string.Empty);
                var authorizedPathIds = authorizedPathUsers.Select(x => x.PathId);
                authorizedPossiblePaths = paths.Where(x => authorizedPathIds.Contains(x.Id)).ToList();
            }

            return authorizedPossiblePaths;
        }


    }
}
