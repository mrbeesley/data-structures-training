using System;
using System.Collections;
using System.Collections.Generic;

namespace StackTraining.Stack.Array
{
    public class Stack<T> : IEnumerable<T>
    {
        T[] _items  = new T[0];
        int _size = 0;

        public void Push(T item)
        {
            // size = 0 .... First push
            // _size == length .... Grow the boundry
            if(_size == _items.Length)
            {
                // if initial push set size to 4 otherwise double the length
                int newLength = _size == 0 ? 4 : _size * 2;

                // allocate, copy and assign the new array
                T[] temp = new T[newLength];
                _items.CopyTo(temp, 0);
                _items = temp;
            }

            // add the item to the stack and increase the size
            _items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("the stack is empty!");
            }

            _size--;
            return _items[_size];
        }

        public T Peek()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("the stack is empty!");
            }

            return _items[_size - 1];
        }

        public int Count { get { return _size; } }

        public void Clear()
        {
            _size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}