using System;

namespace EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int number = ReadNumber(start, end);
                }
                catch (Exception ex)
                when(ex is ArgumentOutOfRangeException || ex is OverflowException || ex is FormatException)
                {
                    i = 0;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException($"Input number must be in range [{start}...{end}]!");
            }

            return number;
        }
    }
}
