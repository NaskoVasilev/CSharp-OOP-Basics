using SoftUniTimer.Core.Contracts;
using SoftUniTimer.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SoftUniTimer.Core.Commands
{
    public class RestartCommand : ICommand
    {
        private readonly string[] inputArgs;

        public RestartCommand(string[] inputArgs)
        {
            this.inputArgs = inputArgs;
        }

        public string Execute()
        {
            if (inputArgs.Length < 1 || string.IsNullOrEmpty(inputArgs[0]))
            {
                throw new ArgumentNullException("Parameters count mismatch!");
            }

            int minutes = int.Parse(inputArgs[0]);
            int seconds = minutes.ToSeconds();

            Process.Start("shutdown", $"/r /t {seconds}");

            return $"Windows will restart afeter {minutes}m.";
        }
    }
}
