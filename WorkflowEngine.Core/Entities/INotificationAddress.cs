﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public interface INotificationAddress
    {
        string Address { get; }
        bool IsValid();
    }
}
