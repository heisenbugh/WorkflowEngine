using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Progress> Progress { get; set; }
        public IList<Request> Requests { get; set; }
        public IList<PathUser> PathUsers { get; set; }
        public IList<StateUser> StateUsers { get; set; }
        public IList<ProcessAdmin> ProcessAdmins { get; set; }
    }
}
