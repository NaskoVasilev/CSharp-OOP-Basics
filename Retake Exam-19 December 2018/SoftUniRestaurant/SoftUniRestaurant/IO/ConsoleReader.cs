using SoftUniRestaurant.IO.Contracts;
using System;

namespace SoftUniRestaurant.IO
{
    class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
