using System;

namespace FixingVol2
{
    class FixingVol2
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} X {num2} = {result}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            Console.ReadLine();
        }
    }
}
