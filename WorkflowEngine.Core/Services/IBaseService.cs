using Haskap.LayeredArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.UnitOfWork;

namespace WorkflowEngine.Core.Services
{
    public interface IBaseService : IBaseService<IWorkflowEngineUnitOfWork>
    {
    }
}
