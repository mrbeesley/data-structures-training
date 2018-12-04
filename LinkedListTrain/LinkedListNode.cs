namespace LinkedListTrain
{
    public class LinkedListNode<T>
    {
        /// <summary>
        /// constructs a new node with the specified value
        /// </summary>
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// the node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// the next node in the linked list (null if last node)
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }
}