using SoftUniTimer.Core;
using SoftUniTimer.Core.Contracts;
using System;

namespace SoftUniTimer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //shutdown 30
            //restart 30
            //hibernate 30
            //abort
            //exit
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
            //Engine -> Run
            //CommandParser/CommandInterpreter
            //Command Pattern
        }
    }
}
