using System;
using HashTableTraining.Hash.Algorithm;

namespace HashTableTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var additive = new Additive();
            var folding = new Folding();
            var djb2 = new DJB2();

            while(!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("> ");
                input = Console.ReadLine();

                Console.WriteLine($"Additive: {additive.Hash(input)}");
                Console.WriteLine($"Folding: {folding.Hash(input)}");
                Console.WriteLine($"djb2: {djb2.Hash(input)}");
            }
        }
    }
}
