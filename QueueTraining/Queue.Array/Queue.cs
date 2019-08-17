using System;
using System.Collections.Generic;

namespace QueueTraining.Queue.Array
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];

        // the number of items in the queue
        private int _size = 0;

        // the index of the first item in the queue
        private int _head = 0;

        // the index of the last item in the queue
        private int _tail = 0;

        private void GrowInternalArray()
        {
            if(_items.Length < _size)
            {
                return;
            }

            var newLenth = (_size == 0) ? 4 : _size * 2;
            var newArray = new T[newLenth];
            if(_size > 0)
            {
                // Copy Contents:
                // if the array has no wrapping just copy the valid range
                // else copy from head to end of range and then 0 to tail
                // if tail < head we are wrapped
                var targetIndex = 0;
                if(_tail < _head)
                {
                    for(int index = _head; index < _items.Length; index++)
                    {
                        newArray[targetIndex] = _items[index];
                        targetIndex++;
                    }

                    for(int index = 0; index <= _tail; index++)
                    {
                        newArray[targetIndex] = _items[index];
                        targetIndex++;
                    }
                }
                else
                {
                    for(int index = _head; index <= _tail; index++)
                    {
                        newArray[targetIndex] = _items[index];
                        targetIndex++;
                    }
                }
                _head = 0;
                _tail = targetIndex - 1;
            }
            else
            {
                _head = 0;
                _tail = -1;
            }
            _items = newArray;
        }

        public void Enqueue(T item)
        {
            GrowInternalArray();
            
            // if tail is at the end then we need to wrap.
            if(_tail == _items.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }
            _items[_tail] = item;
            _size++;
        }

        /// <summary>
        /// returns and removes the head item
        /// </summary>
        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items[_head];
            if(_head == _items.Length-1)
            {
                // if the head is the last index in the array wrap around
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;
            return value;
        }

        /// <summary>
        /// returns the head item but doesn't remove it.
        /// </summary>
        public T Peek()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            return _items[_head];
        }

        /// <summary>
        /// the number of items in the queue
        /// </summary>
        public int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// removes all of the items from the queue
        /// </summary>
        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        /// <summary>
        /// returns an enumerator that enumerates the queue.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            if(_size > 0)
            {
                // if the queue wraps handle that case
                if(_tail < _head)
                {
                    // for _head --> end
                    for(int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }

                    // for start --> _tail
                    for(int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    // head --> tail
                    for(int index = _head; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}