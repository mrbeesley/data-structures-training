namespace HashTableTraining.Hash.Implementation
{
    public class HashTableNodePair<TKey, TValue>
    {

        public HashTableNodePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; private set; }
        public TValue Value { get; set; }
    }
}