using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTraining.BinaryTree.Implementation
{
    /// <summary>
    /// A binary tree node class - encapsulates the value and left/right pointers.
    /// </summary>
    /// <typeparam name="TNode">a generic type that is IComparable</typeparam>
    public class BinaryTreeNode<TNode> : IComparable<TNode>
        where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public TNode Value { get; private set; }

        /// <summary>
        /// compares the current node to the provided value
        /// </summary>
        /// <param name="other">the node to compare to</param>
        /// <returns>1 if the instance is greater than the provided value, -1 if less and 0 if equal</returns>
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
