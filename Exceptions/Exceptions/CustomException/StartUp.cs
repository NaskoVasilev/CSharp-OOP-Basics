using System;

namespace CustomException
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "abv@abv.bg");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
