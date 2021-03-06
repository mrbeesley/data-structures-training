using System.Collections.Generic;
using System;

namespace StackTraining.Stack.LinkedList
{
    public class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        public T Pop()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            var value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return _list.First.Value;
        }

        public int Count { get { return _list.Count; } }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}