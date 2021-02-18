using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class Request : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ProcessId { get; set; }
        public Process Process { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public Guid? CurrentStateId { get; set; }
        public State CurrentState { get; set; }
        public IList<Progress> Progress { get; set; }
        public RequestData Data { get; set; }
    }
}
