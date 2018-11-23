using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniTimer.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] inputArgs);
    }
}
