using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class Path : BaseEntity
    {
        public Guid FromStateId { get; set; }
        public State FromState { get; set; }
        public Guid ActionId { get; set; }
        public Action Action { get; set; }
        public Guid ToStateId { get; set; }
        public State ToState { get; set; }
        public IList<Progress> Progress { get; set; }
        public IList<PathUser> PathUsers { get; set; }
    }
}
