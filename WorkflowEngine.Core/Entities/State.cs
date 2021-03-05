using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public string CodeName { get; set; }
        public Guid? ProcessId { get; set; }
        public Process Process { get; set; }
        public string PartialViewName { get; set; }
        public IList<Path> FromPaths { get; set; }
        public IList<Path> ToPaths { get; set; }
        public IList<StateUser> StateUsers { get; set; }
        public IList<Request> Requests { get; set; }
        public StateType StateType { get; set; }
    }
}
