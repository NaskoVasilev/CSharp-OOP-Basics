using System;

namespace DateModifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();

            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            Console.WriteLine(dateModifier.ClaculateDaysDiffernce(startDate, endDate));
        }
    }
}
