using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class PathUser : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PathId { get; set; }
        public Path Path { get; set; }
    }
}
