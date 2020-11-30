using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class StateUser : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
    }
}
