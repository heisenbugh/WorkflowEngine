using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class ActionType : BaseEntity
    {
        //RestartAction, NormalAction
        public string Name { get; set; }
        public ICollection<Action> Actions { get; set; }
    }
}
