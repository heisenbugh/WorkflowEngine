using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class Process : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<State> States { get; set; }
        public IList<Request> Requests { get; set; }
        public IList<Action> Actions { get; set; }
        public IList<ProcessAdmin> ProcessAdmins { get; set; }

    }
}
