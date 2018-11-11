using Society.Core;
using System;

namespace Society
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Problem 5 Border Control
            //BorderControl border = new BorderControl();
            //border.Run();


            //Problem 6. Birthday Celebrations
            //BirthdayCelebration birthday = new BirthdayCelebration();
            //birthday.Run();


            //Problem 7. Food Shortage
            FoodStorage foodStorage = new FoodStorage();
            foodStorage.Run();

        }
    }
}
