using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Implementation
{
    public class HashTable<TKey, TValue>
    {
        // =====> if the array exceeds this fill percentage it will grow
        // =====> in this example the fill factor is the total number of items
        // =====> regardless of whether there are collisions or not
        const double _fillFactor = 0.75;

        // =====> the maximum number of items to store before growing
        // =====> this is just a cached value of fill factor calculation
        int _maxItemsAtCurrentSize;

        // =====> the number of items in the hash table
        int _count;

        // =====> the array where the items are stored.
        HashTableArray<TKey, TValue> _array;

        /// <summary>
        /// Constructs a hash table with the default capacity
        /// </summary>
        public HashTable() : this(1000) { }
        public HashTable(int initialCapacity)
        {
            if(initialCapacity < 1)
                throw new ArgumentOutOfRangeException("initialCapacity");

            _array = new HashTableArray<TKey, TValue>(initialCapacity);
            _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;
        }

        public void Add(TKey key, TValue value)
        {
            if(_count >= _maxItemsAtCurrentSize)
            {
                var largerArray = new HashTableArray<TKey, TValue>(_array.Capacity * 2);

                foreach(var node in _array.Items)
                {
                    largerArray.Add(node.Key, node.Value);
                }

                _array = largerArray;
                _maxItemsAtCurrentSize = (int)(_array.Capacity * _fillFactor) + 1;
            }
            _array.Add(key, value);
            _count++;
        }

        public bool Remove(TKey key)
        {
            var removed = _array.Remove(key);
            if (removed)
                _count--;
            return removed;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!_array.TryGetValue(key, out value))
                    throw new ArgumentException("key");
                return value;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array.TryGetValue(key, out value);
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return _array.TryGetValue(key, out value);
        }

        public bool ContainsValue(TValue value)
        {
            foreach(var foundValue in _array.Values)
            {
                if (value.Equals(foundValue))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerator for all of the keys in the hash table
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (TKey key in _array.Keys)
                {
                    yield return key;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator for all of the values in the hash table
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (TValue value in _array.Values)
                {
                    yield return value;
                }
            }
        }

        public void Clear()
        {
            _array.Clear();
            _count = 0;
        }

        public int Count { get => _count; }
    }
}
