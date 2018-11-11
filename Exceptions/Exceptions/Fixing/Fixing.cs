using System;

namespace Fixing
{
    class Fixing
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5];

            weekDays[0] = "Monday";
            weekDays[1] = "Tuesday";
            weekDays[2] = "Wednesday";
            weekDays[3] = "Thursday";
            weekDays[4] = "Friday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                Console.WriteLine(ie.Message);
            }

            Console.ReadLine();
        }
    }
}
