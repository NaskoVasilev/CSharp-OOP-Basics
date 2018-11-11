using System;

namespace ConvertToDouble
{
    class ConvertToDouble
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                double number = Convert.ToDouble(input);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw;
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                throw;
            }
        }
    }
}
