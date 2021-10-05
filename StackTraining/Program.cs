using System;
using arr = StackTraining.Stack.Array;
using lnk = StackTraining.Stack.LinkedList;
using StackTraining.Stack.Calc;

namespace StackTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            #region working with stack...
            /*

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

            */
            #endregion 

            #region working witht the calulator...

            // ex | 5 6 7 * + 1 - 
            var calc = new Calculator();
            // var tokens = new string[] { "5", "6", "7", "*", "+", "1", "-"};
            var tokens = new string[] { "5", "2", "+" };
            var flatTokens = string.Join(" ", tokens);
            Console.WriteLine($"Calculating value for: {flatTokens}");
            var result = calc.Calculate(tokens);
            Console.WriteLine($"Result = {result}");

            #endregion
        
        }
    }
}
