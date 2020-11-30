using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class Progress : BaseEntity
    {
        public Guid RequestId { get; set; }
        public Request Request { get; set; }
        public Guid? PathId { get; set; }
        public Path Path { get; set; }
        public Guid? ProgressedById { get; set; }
        public User ProgressedBy { get; set; }
        public DateTime ProgressDate { get; set; }
        public string Message { get; set; }
    }
}
