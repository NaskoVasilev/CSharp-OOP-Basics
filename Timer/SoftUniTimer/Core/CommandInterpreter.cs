using SoftUniTimer.Core.Commands;
using SoftUniTimer.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniTimer.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICommand command;

        public string Read(string[] inputArgs)
        {
            string action = inputArgs[0];
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (action)
            {
                case "shutdown":
                    command = new ShutdownCommand(inputArgs);
                    break;
                case "restart":
                    command = new RestartCommand(inputArgs);
                    break;
                case "hibernate":
                    command = new HibernateCommand(inputArgs);
                    break;
                case "abort":
                    command = new AbortCommand();
                    break;
                case "exit":
                    command = new ExitCommand();
                    break;
                default:
                    break;
            }

            if (command == null)
            {
                throw new ArgumentNullException("Command is not supported!");
            }

            var result = command.Execute();

            return result;
        }
    }
}
