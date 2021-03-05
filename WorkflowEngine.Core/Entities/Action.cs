using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class Action : BaseEntity
    {
        public string Name { get; set; }
        public string CodeName { get; set; }
        public Guid? ProcessId { get; set; }
        public Process Process { get; set; }
        public IList<Path> Paths { get; set; }
        public ActionType ActionType { get; set; }
    }
}
