using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowseable, ICallable
    {
        public void Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

        public void Call(string number)
        {
            if (number.All(x => char.IsDigit(x)))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
