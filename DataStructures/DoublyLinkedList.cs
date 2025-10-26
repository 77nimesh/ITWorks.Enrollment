using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// A simple generic doubly linked list implementation.
    /// Provides basic list operations such as add/remove, search and enumeration.
    /// </summary>
    public class DoublyLinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// Gets the head (first) node of the list. Returns null if the list is empty.
        /// </summary>
        public DoublyLinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// Gets the tail (last) node of the list. Returns null if the list is empty.
        /// </summary>
        public DoublyLinkedListNode<T> Tail { get; private set; }

        /// <summary>
        /// Gets the number of elements contained in the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only. Always false for this implementation.
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        // ---------- AddFirst(value) ----------
        /// <summary>
        /// Inserts a new element at the start of the list.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        public void AddFirst(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);
            AddFirst(node);
        }

        // ---------- AddFirst(node) ----------
        /// <summary>
        /// Inserts an existing node at the start of the list.
        /// </summary>
        /// <param name="node">The node to insert. Cannot be null.</param>
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node");

            if (Head == null)
            {
                // empty list
                Head = node;
                Tail = node;
                node.Previous = null;
                node.Next = null;
            }
            else
            {
                node.Next = Head;
                node.Previous = null;
                Head.Previous = node;
                Head = node;
            }
            Count++;
        }

        // ---------- AddLast(value) ----------
        /// <summary>
        /// Appends a new element at the end of the list.
        /// </summary>
        /// <param name="value">The value to append.</param>
        public void AddLast(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);
            AddLast(node);
        }

        // ---------- AddLast(node) ----------
        /// <summary>
        /// Appends an existing node at the end of the list.
        /// </summary>
        /// <param name="node">The node to append. Cannot be null.</param>
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node");

            if (Tail == null)
            {
                // empty list
                Head = node;
                Tail = node;
                node.Previous = null;
                node.Next = null;
            }
            else
            {
                node.Previous = Tail;
                node.Next = null;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        // ---------- ICollection<T>.Add (append) ----------
        /// <summary>
        /// Appends an item to the tail of the list. Implements <c>ICollection&lt;T&gt;.Add</c>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            AddLast(item);
        }

        // ---------- RemoveFirst (O(1)) ----------
        /// <summary>
        /// Removes and returns the first element of the list.
        /// Throws <see cref="InvalidOperationException"/> if the list is empty.
        /// </summary>
        /// <returns>The removed element.</returns>
        public T RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("List is empty.");

            var value = Head.Value;

            if (Head == Tail)
            {
                // single node
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }

            Count--;
            return value;
        }

        // ---------- RemoveLast (O(1)) ----------
        /// <summary>
        /// Removes and returns the last element of the list.
        /// Throws <see cref="InvalidOperationException"/> if the list is empty.
        /// </summary>
        /// <returns>The removed element.</returns>
        public T RemoveLast()
        {
            if (Tail == null) throw new InvalidOperationException("List is empty.");

            var value = Tail.Value;

            if (Head == Tail)
            {
                // single node
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }

            Count--;
            return value;
        }

        // ---------- Remove(item): remove first occurrence ----------
        /// <summary>
        /// Removes the first occurrence of the specified item from the list.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if an element was removed; otherwise false.</returns>
        public bool Remove(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            var current = Head;

            while (current != null)
            {
                if (comparer.Equals(current.Value, item))
                {
                    // unlink current
                    if (current.Previous == null)
                    {
                        // removing head
                        Head = current.Next;
                        if (Head != null) Head.Previous = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    if (current.Next == null)
                    {
                        // removing tail
                        Tail = current.Previous;
                        if (Tail != null) Tail.Next = null;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // ---------- Contains ----------
        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns>True if the item exists in the list; otherwise false.</returns>
        public bool Contains(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            var n = Head;
            while (n != null)
            {
                if (comparer.Equals(n.Value, item)) return true;
                n = n.Next;
            }
            return false;
        }

        // ---------- CopyTo ----------
        /// <summary>
        /// Copies the elements of the list to the specified array starting at the specified index.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The zero-based index in the destination array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("Destination array is too small.");

            var n = Head;
            while (n != null)
            {
                array[arrayIndex++] = n.Value;
                n = n.Next;
            }
        }

        // ---------- Clear ----------
        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // ---------- Enumerators ----------
        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var n = Head;
            while (n != null)
            {
                yield return n.Value;
                n = n.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
