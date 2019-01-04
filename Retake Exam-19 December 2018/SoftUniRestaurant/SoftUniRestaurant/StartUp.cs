using SoftUniRestaurant.Core;
using SoftUniRestaurant.IO;
using SoftUniRestaurant.IO.Contracts;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            RestaurantController restaurantController = new RestaurantController();

            Engine engine = new Engine(restaurantController, writer, reader);
            engine.Run();
        }
    }
}
