using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.Core.Services
{
    public interface IWorkflowEngineService : IBaseService
    {
        State GetStartState(Guid processId);
        State GetRequestCurrentState(Guid requestId);
        State GetRequestNextState(Guid requestId, string actionCodeName, Guid userId);
        Progress SaveProgress(Guid requestId, string actionCodeName, Guid userId, string message, RequestData data);
        IList<Path> GetPossibleRequestPaths(Guid requestId, Guid userId);
    }
}
