using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Simple integer binary search tree implementation.
    /// Supports insertion, search, removal and tree traversals.
    /// </summary>
    public class BinarySearchTree
    {
        /// <summary>
        /// Gets or sets the root node of the tree.
        /// </summary>
        public Node Root { get; set; }

        /// <summary>
        /// Insert a value into the BST. Returns true if inserted; false if duplicate.
        /// </summary>
        /// <param name="value">The integer value to add.</param>
        /// <returns>True if the value was added; false if a duplicate existed.</returns>
        public bool Add(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return true;
            }

            Node current = Root;
            while (true)
            {
                if (value == current.Data)
                {
                    // duplicate: ignore (or choose a policy to place duplicates to right)
                    return false;
                }
                else if (value < current.Data)
                {
                    if (current.LeftNode == null)
                    {
                        current.LeftNode = new Node(value);
                        return true;
                    }
                    current = current.LeftNode;
                }
                else // value > current.Data
                {
                    if (current.RightNode == null)
                    {
                        current.RightNode = new Node(value);
                        return true;
                    }
                    current = current.RightNode;
                }
            }
        }


        /// <summary>
        /// Finds and returns the node with the specified value, or null if not found.
        /// </summary>
        /// <param name="value">The value to locate.</param>
        /// <returns>The node if found; otherwise null.</returns>
        public Node Find(int value)
        {
            Node current = Root;
            while (current != null)
            {
                if (value == current.Data) return current;
                current = (value < current.Data) ? current.LeftNode : current.RightNode;
            }
            return null;
        }


        /// <summary>
        /// Removes the specified value from the tree if present.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        public void Remove(int value)
        {
            Root = Remove(Root, value);
        }


        private Node Remove(Node current, int value)
        {
            if (current == null) return null;

            if (value < current.Data)
            {
                current.LeftNode = Remove(current.LeftNode, value);
            }
            else if (value > current.Data)
            {
                current.RightNode = Remove(current.RightNode, value);
            }
            else
            {
                // found node to remove
                if (current.LeftNode == null && current.RightNode == null)
                {
                    // case 1: leaf
                    return null;
                }
                else if (current.LeftNode == null)
                {
                    // case 2: one child (right)
                    return current.RightNode;
                }
                else if (current.RightNode == null)
                {
                    // case 2: one child (left)
                    return current.LeftNode;
                }
                else
                {
                    // case 3: two children
                    int successor = MinValue(current.RightNode);
                    current.Data = successor;
                    current.RightNode = Remove(current.RightNode, successor);
                }
            }
            return current;
        }


        private int MinValue(Node node)
        {
            Node current = node;
            while (current.LeftNode != null)
                current = current.LeftNode;
            return current.Data;
        }


        /// <summary>
        /// Returns the depth (height) of the tree.
        /// </summary>
        /// <returns>Depth as an integer (0 for empty tree).</returns>
        public int GetTreeDepth()
        {
            return Depth(Root);
        }

        private int Depth(Node node)
        {
            if (node == null) return 0;
            int left = Depth(node.LeftNode);
            int right = Depth(node.RightNode);
            return (left > right ? left : right) + 1;
        }

        // ---------------- Traversals ----------------
        // Use Action<int> visitor to keep this a pure library (no Console required).
        // For demo, you can pass: x => Console.Write(x + " ");


        /// <summary>
        /// Traverses the tree in pre-order and invokes the provided visitor for each node value.
        /// </summary>
        /// <param name="visit">The action to invoke for each node value.</param>
        public void TraversePreOrder(Action<int> visit)
        {
            if (visit == null) throw new ArgumentNullException("visit");
            TraversePreOrder(Root, visit);
        }

        private void TraversePreOrder(Node node, Action<int> visit)
        {
            if (node == null) return;
            visit(node.Data);
            TraversePreOrder(node.LeftNode, visit);
            TraversePreOrder(node.RightNode, visit);
        }


        /// <summary>
        /// Traverses the tree in in-order (left-root-right) and invokes the provided visitor for each node value.
        /// </summary>
        /// <param name="visit">The action to invoke for each node value.</param>
        public void TraverseInOrder(Action<int> visit)
        {
            if (visit == null) throw new ArgumentNullException("visit");
            TraverseInOrder(Root, visit);
        }

        private void TraverseInOrder(Node node, Action<int> visit)
        {
            if (node == null) return;
            TraverseInOrder(node.LeftNode, visit);
            visit(node.Data);
            TraverseInOrder(node.RightNode, visit);
        }


        /// <summary>
        /// Traverses the tree in post-order and invokes the provided visitor for each node value.
        /// </summary>
        /// <param name="visit">The action to invoke for each node value.</param>
        public void TraversePostOrder(Action<int> visit)
        {
            if (visit == null) throw new ArgumentNullException("visit");
            TraversePostOrder(Root, visit);
        }

        private void TraversePostOrder(Node node, Action<int> visit)
        {
            if (node == null) return;
            TraversePostOrder(node.LeftNode, visit);
            TraversePostOrder(node.RightNode, visit);
            visit(node.Data);
        }

        // -------- Convenience helpers to get traversal results as arrays --------

        /// <summary>
        /// Returns an array of node values in pre-order.
        /// </summary>
        public int[] ToPreOrderArray()
        {
            List<int> list = new List<int>();
            TraversePreOrder(delegate (int x) { list.Add(x); });
            return list.ToArray();
        }

        /// <summary>
        /// Returns an array of node values in in-order.
        /// </summary>
        public int[] ToInOrderArray()
        {
            List<int> list = new List<int>();
            TraverseInOrder(delegate (int x) { list.Add(x); });
            return list.ToArray();
        }

        /// <summary>
        /// Returns an array of node values in post-order.
        /// </summary>
        public int[] ToPostOrderArray()
        {
            List<int> list = new List<int>();
            TraversePostOrder(delegate (int x) { list.Add(x); });
            return list.ToArray();
        }

    }
}
