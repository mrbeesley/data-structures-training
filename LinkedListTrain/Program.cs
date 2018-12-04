using System;

namespace LinkedListTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            var testList = new LinkedList<int>();
            testList.Add(7);
            testList.Add(5);
            testList.Add(3);
            testList.Add(1);

            foreach(var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
