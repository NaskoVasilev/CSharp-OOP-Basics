using System;

namespace CustomRandomList
{
    public class StartUp
    {
         public static void Main(string[] args)
        {
            RandomList list = new RandomList
            {
                "1",
                "2",
                "3",
                "4"
            };

            while (list.Count > 0)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
