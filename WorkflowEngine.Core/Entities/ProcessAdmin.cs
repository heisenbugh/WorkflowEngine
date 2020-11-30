using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class ProcessAdmin : BaseEntity
    {
        public Guid ProcessId { get; set; }
        public Process Process { get; set; }
        public Guid AdminId { get; set; }
        public User Admin { get; set; }
    }
}
