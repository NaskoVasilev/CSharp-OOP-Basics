using System;

namespace RhombusOfStars
{
    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                PrintRow(rows, i);
            }

            for (int i = rows - 1; i >= 1; i--)
            {
                PrintRow(rows, i);
            }
        }

        private static void PrintRow(int rows, int starsCount)
        {
            for (int i = 0; i < rows - starsCount; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < starsCount - 1; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
