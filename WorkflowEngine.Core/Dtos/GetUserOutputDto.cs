using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Core.Dtos
{
    public class GetUserOutputDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
