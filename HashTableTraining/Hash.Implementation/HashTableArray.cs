using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Implementation
{
    public class HashTableArray<TKey, TValue>
    {
        HashTableArrayNode<TKey, TValue>[] _array;

        /// <summary>
        /// constructs a new hash table array with the specified capacity
        /// </summary>
        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for(int i = 0; i < capacity; i++)
            {
                _array[i] = new HashTableArrayNode<TKey, TValue>();
            }
        }

        /// <summary>
        /// adds the key/value pair to the node if the key already exists in the
        /// node array an ArgumentException will be thrown
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        /// <summary>
        /// Updates the value of the existing key/value pair in the node array
        /// if the key does not exists in the array an argument exception 
        /// will be thrown
        /// </summary>
        public void Update(TKey key, TValue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        public bool Remove(TKey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        public int Capacity { get => _array.Length; }

        public void Clear()
        {
            foreach(HashTableArrayNode<TKey, TValue> node in _array)
            {
                node.Clear();
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach(var node in _array)
                {
                    foreach(var value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (var node in _array)
                {
                    foreach (var key in node.Keys)
                    {
                        yield return key;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach (var node in _array)
                {
                    foreach (var pair in node.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }
    }
}
