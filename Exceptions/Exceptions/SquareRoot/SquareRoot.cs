using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException();
                }
                double squareRoot = Math.Sqrt(number);
                Console.WriteLine(squareRoot);
            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is FormatException || ex is OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
