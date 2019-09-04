using System;
using BinaryTreeTraining.BinaryTree.Implementation;
using System.Linq;

namespace BinaryTreeTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<string>();
            var input = string.Empty;

            while(!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Write("> ");
                input = Console.ReadLine();
                var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                    tree.Add(word);
                Console.WriteLine($"{tree.Count} words");
                foreach (var word in tree)
                    Console.Write($"{word} ");
                Console.WriteLine();
                tree.Clear();
            }
        }
    }
}
