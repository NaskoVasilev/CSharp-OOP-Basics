using SoftUniRestaurant.IO.Contracts;
using System;
using System.Text;

namespace SoftUniRestaurant.IO
{
    public class ConsoleWriter : IWriter
    {
        private StringBuilder sb;

        public ConsoleWriter()
        {
            this.sb = new StringBuilder();
        }

        public void AppendLine(string message)
        {
            sb.AppendLine(message);
        }

        public void WriteAllLines()
        {
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
