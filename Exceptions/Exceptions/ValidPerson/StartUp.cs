using System;

namespace ValidPerson
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Atanas", "Vasilev", 16);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
