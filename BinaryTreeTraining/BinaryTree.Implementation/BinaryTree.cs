using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTraining.BinaryTree.Implementation
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        #region Add

        /// <summary>
        /// Adds the provided value to the binary tree.
        /// </summary>
        /// <param name="value">the value to add.</param>
        public void Add(T value)
        {
            if(_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            _count++;
        }

        /// <summary>
        /// recursive add algorithm
        /// </summary>
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // CASE 1:
            // =====> Value is less than the current node value.
            if(value.CompareTo(node.Value) < 0)
            {
                if(node.Left == null)
                {
                    // =====> If there is no left node add it.
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // =====> Else call AddTo on the left node.
                    AddTo(node.Left, value);
                }
            }
            // CASE 2:
            // =====> Value is greater than or equal to node value
            else
            {
                if(node.Right == null)
                {
                    // =====> If there is no right value on the node add it.
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // =====> else call AddTo on the right node.
                    AddTo(node.Right, value);
                }
            }
        }

        #endregion // Add

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;

            while(current != null)
            {
                int result = current.CompareTo(value);

                if(result > 0)
                {
                    // =====> If the value is less than the parent go left.
                    parent = current;
                    current = current.Left;
                }
                else if(result < 0)
                {
                    // =====> if the value is greater than the parent go right
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        #region Remove

        /// <summary>
        /// Removes the first occurance of the specified value from the tree.
        /// </summary>
        /// <param name="value">the value to remove</param>
        /// <returns>TRUE if value was removed, FALSE if not</returns>
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);
            if (current == null)
                return false;

            _count--;

            //CASE 1:
            // =====> if current has no right child, then current's left replaces current.
            if(current.Right == null)
            {
                if(parent == null)
                {
                    // =====> there was no parent which means this was the head value so move the left value to head.
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // =====> if parent value is greater than current value
                        // =====> make the current left child a left child of parent
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // =====> if parent value is less than current value
                        // =====> make the current left child a right child of parent
                        parent.Right = current.Left;
                    }
                }
            }
            // CASE 2: 
            // =====> if current's right child has no left child, then currents right child replaces current.
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if(parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // =====> if parent value is greater than current value
                        // =====> make the current right child a left child of parent
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // =====> if parent value is less than current value
                        // =====> make the current right child a right child of parent
                        parent.Right = current.Right;
                    }
                }
            }
            // CASE 3:
            // =====> if current's right child has a left child, replace current with current's right child's left-most child
            else
            {
                // =====> find the right's left-most child
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;
                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                // =====> the parent's left subtree becomes the leftmost's right subtree
                leftMostParent.Left = leftMost.Right;

                // =====> assign the leftmost's left and right to current's left and right children
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if(parent == null)
                {
                    _head = leftMost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // =====> if parent value is greater than current value
                        // =====> make leftmost the parent's left child
                        parent.Left = leftMost;
                    }
                    else if(result > 0)
                    {
                        // =====> if parent value is less than current value
                        // =====> make leftmost the parents right child
                        parent.Right = leftMost;
                    }
                }
            }
            return true;
        }

        #endregion // Remove

        #region Pre-Order Traversal

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if(node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        #endregion // Pre-Order Traversal

        #region Post-Order Traversal

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if(node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        #endregion // Post-Order Traversal

        #region In-Order Enumeration

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if(node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        /// Enumerate the values in the binary tree in-order traversal order.
        /// this is a non-recursive traversal algorith.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> InOrderTraversal()
        {
            if(_head != null)
            {
                // =====> store the nodes we've skipped in this stack
                var stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _head;

                // =====> when removing recursion we need to keep track of whether or not
                // =====> we should be going to the left node or the right nodes next
                var goLeftNext = true;

                stack.Push(current);

                while(stack.Count > 0)
                {
                    // =====> If we are going left
                    if (goLeftNext)
                    {
                        // =====> push everything but the left-most node to the stack
                        // =====> we will yield the left-most after this block
                        while(current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    // =====> In-Order is left->yield->right
                    yield return current.Value;

                    // =====> If we can go right then do so
                    if(current.Right != null)
                    {
                        current = current.Right;
                        // =====> once we've gone right once 
                        // =====> we need to start going left again
                        goLeftNext = true;
                    }
                    else
                    {
                        // =====> if we can't go right then we need to pop off the parent node
                        // =====> so we can process it and then go to it's right node
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion // In-Order Enumeration

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public int Count { get => _count; }
    }
}
