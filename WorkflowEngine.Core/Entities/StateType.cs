using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class StateType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
    }
}
