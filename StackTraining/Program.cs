using System;
using arr = StackTraining.Stack.Array;
using lnk = StackTraining.Stack.LinkedList;

namespace StackTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            // var stack = new lnk.Stack<int>();
            var stack = new arr.Stack<int>();

            Console.WriteLine("Pushing values onto the stack...");
            Console.WriteLine("Value Pushed: 7");
            stack.Push(7);
            Console.WriteLine("Value Pushed: 5");
            stack.Push(5);
            Console.WriteLine("Value Pushed: 3");
            stack.Push(3);
            Console.WriteLine("Value Pushed: 1");
            stack.Push(1);

            Console.WriteLine("Popping values off of the stack...");
            while(stack.Count > 0)
            {
                var item = stack.Pop();
                Console.WriteLine($"Value Popped: {item}");
            }
        }
    }
}
