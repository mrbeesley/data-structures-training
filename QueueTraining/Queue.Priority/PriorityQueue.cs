using System;
using System.Collections.Generic;
using System.Text;

namespace QueueTraining.Queue.Priority
{
    public class PriorityQueue<T> : IEnumerable<T> where T: IComparable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            // if the list is empty just add the item
            if(_items.Count == 0)
            {
                _items.AddLast(item);
                return;
            }
            
            
            // we need to find the proper insert point
            var current = _items.First;

            // while we're not at the end of the list and the current value
            // is larger than the value being inserted...
            while(current != null && current.Value.CompareTo(item) > 0)
            {
                current = current.Next;
            }

            if(current == null)
            {
                // we made it to the ned of the list 
                _items.AddLast(item);
            }
            else
            {
                // the current item is <= the one being added
                // so add the item before it
                _items.AddBefore(current, item);
            }
        }

        public T Dequeue()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            // store the last value in a temp variable
            var value = _items.First.Value;

            // remove the last item
            _items.RemoveFirst();

            // return our stored item;
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _items.First.Value;
        }

        public int Count { get { return _items.Count; } }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
