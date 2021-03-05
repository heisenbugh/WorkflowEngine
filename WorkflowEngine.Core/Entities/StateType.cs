using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public enum StateType
    {
        StartState, 
        EndState, 
        NormalState, 
        RecursiveState
    }
}
