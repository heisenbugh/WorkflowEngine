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

        public State GetRequestNextState(Guid requestId, string actionCodeName, Guid userId)
        {
            var request = this.unitOfWork.GetRepository<Request>().GetById(requestId);
            State nextState;
            var isProcessAdmin = this.unitOfWork.GetRepository<ProcessAdmin>().Exists(x => x.AdminId == userId && x.ProcessId == request.ProcessId, string.Empty);
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
            return this.unitOfWork.GetRepository<State>().Get(new StartStateSpecification(processId), x => x.Include(state => state.StateType));
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

        public IList<Path> GetPossibleRequestPaths(Guid requestId, Guid userId)
        {
            var request = this.unitOfWork.GetRepository<Request>().GetById(requestId);
            var paths = this.unitOfWork.GetRepository<Path>().GetMany(x => x.FromStateId == request.CurrentStateId, e => e.Include(x => x.Action).Include(x => x.ToState).Include(x => x.FromState));
            var authorizedPossiblePaths = paths;
            var isProcessAdmin = this.unitOfWork.GetRepository<ProcessAdmin>().Exists(x => x.AdminId == userId && x.ProcessId == request.ProcessId, string.Empty);

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
