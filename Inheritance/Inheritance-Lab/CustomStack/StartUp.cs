using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.Push("5");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty());
        }
    }
}
