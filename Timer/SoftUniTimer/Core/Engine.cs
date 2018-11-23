using SoftUniTimer.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniTimer.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine().ToLower().Split();

                    var result = this.commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
