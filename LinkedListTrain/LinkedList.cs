using System.Collections.Generic;
using System.Collections;

namespace LinkedListTrain
{
    public class LinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// the first node in the list or null if empty
        /// </summary>
        public LinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// the last node in the list or null if empty
        /// </summary>
        public LinkedListNode<T> Tail { get; private set; }

        #region Add

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            // save the head so we don't lose it
            LinkedListNode<T> temp = Head;
            // set the new node to the head value
            Head = node;
            // set the previous head to next of the new head
            Head.Next = temp;

            Count++;
            if(Count == 1)
            {
                // if the list was empty then head and tail should both point to the new node
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if(Count == 0)
            {
                // if the list is empty then this is the head node
                Head = node;
            }
            else 
            {
                // set the next value of the current tail to this node
                Tail.Next = node;
            }
            // set this node as the new tail.
            Tail = node;
            Count++;
        }

        #endregion // Add

        #region Remove

        public void RemoveFirst()
        {
            if(Count != 0)
            {
                Head = Head.Next;
                Count--;
                if(Count == 0)
                {
                    Tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            if(Count != 0)
            {
                if(Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    LinkedListNode<T> current = Head;
                    while(current.Next != Tail)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Tail = current;
                }
                Count--;
            }
        }

        #endregion // Remove

        #region ICollection

        public int Count 
        { 
            get; 
            private set; 
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while(current.Next != null)
            {
                if(current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while(current.Next != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool IsReadOnly
        {
            get 
            {
                return false;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            while(current.Next != null)
            {
                if(current.Value.Equals(item))
                {
                    if(previous != null)
                    {
                        // remove the current item
                        previous.Next = current.Next;

                        // it was the tail so update new tail
                        if(current.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        #endregion // ICollection
    }
}