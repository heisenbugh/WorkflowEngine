using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Entities
{
    public class RequestData : BaseEntity
    {
        public Guid RequestId { get; set; }
        public Request Request { get; set; }
    }
}
