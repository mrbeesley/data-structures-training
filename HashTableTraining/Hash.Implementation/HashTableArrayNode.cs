﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Implementation
{
    public class HashTableArrayNode<TKey, TValue>
    {
        LinkedList<HashTableNodePair<TKey, TValue>> _items;

        public void Add(TKey key, TValue value)
        {
            if(_items == null)
            {
                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();
            }
            else
            {
                foreach(var pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        throw new ArgumentException("the collection already contains the key");
                    }
                }
            }

            _items.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));
        }


        public void Update(TKey key, TValue value)
        {
            var updated = false;
            if(_items != null)
            {
                foreach(var pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        pair.Value = value;
                        updated = true;
                        break;
                    }
                }
            }
            if (!updated)
                throw new ArgumentException("The collection doesn't contain the key");
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            var found = false;
            if(_items != null)
            {
                foreach(var pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        public bool Remove(TKey key)
        {
            var removed = false;
            if(_items != null)
            {
                var current = _items.First;
                while(current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        _items.Remove(current);
                        removed = true;
                        break;
                    }
                    current = current.Next;
                }
            }
            return removed;
        }

        public void Clear()
        {
            if(_items != null)
            {
                _items.Clear();
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                if(_items != null)
                {
                    foreach (var node in _items)
                        yield return node.Value;
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                        yield return node.Key;
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                        yield return node;
                }
            }
        }

    }
}
