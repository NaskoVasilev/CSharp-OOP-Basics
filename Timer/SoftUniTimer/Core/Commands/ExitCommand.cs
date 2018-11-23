using SoftUniTimer.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniTimer.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute()
        {
            Console.WriteLine("Bye bye!");
            Environment.Exit(0);
            return null;
        }
    }
}
