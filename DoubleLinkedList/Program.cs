using System;
using System.Linq;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            list.Add(11);
            list.Add(9);
            list.Add(7);
            list.Add(5);
            list.Add(3);
            list.Add(1);

            Console.WriteLine("Enumerate List: 1,3,5,7,9,11");
            Printist(list);


            Console.WriteLine("remove 5 and 7");
            list.Remove(5);
            list.Remove(7);
            Console.WriteLine("Enumerate List: 1,3,9,11");
            Printist(list);

            Console.WriteLine("Add 5 and 7 back in");
            list.Add(5);
            list.Add(7);
            Console.WriteLine("Enumerate List: 7,5,1,3,9,11");
            Printist(list);
        }

        private static void Printist(LinkedList<int> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
