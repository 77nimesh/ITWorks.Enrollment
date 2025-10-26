using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// A simple generic singly linked list implementation.
    /// Provides basic list operations such as add/remove, search and enumeration.
    /// </summary>
    public class SinglyLinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// Gets the head (first) node of the list. Returns null if the list is empty.
        /// </summary>
        public SinglyLinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// Gets the tail (last) node of the list. Returns null if the list is empty.
        /// </summary>
        public SinglyLinkedListNode<T> Tail { get; private set; }

        /// <summary>
        /// Gets the number of elements contained in the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only. Always false for this implementation.
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        // -------- AddFirst (value) --------
        /// <summary>
        /// Inserts a new element at the start of the list.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        public void AddFirst(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);
            node.Next = Head;
            Head = node;
            if (Tail == null) Tail = Head;
            Count++;
        }

        // -------- AddFirst (node) --------
        /// <summary>
        /// Inserts an existing node at the start of the list.
        /// </summary>
        /// <param name="node">The node to insert. Cannot be null.</param>
        public void AddFirst(SinglyLinkedListNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node");
            node.Next = Head;
            Head = node;
            if (Tail == null) Tail = Head;
            Count++;
        }

        // -------- AddLast (value) --------
        /// <summary>
        /// Appends a new element at the end of the list.
        /// </summary>
        /// <param name="value">The value to append.</param>
        public void AddLast(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        // -------- AddLast (node) --------
        /// <summary>
        /// Appends an existing node at the end of the list.
        /// </summary>
        /// <param name="node">The node to append. Cannot be null.</param>
        public void AddLast(SinglyLinkedListNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node");
            node.Next = null; // it becomes the tail
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        // -------- ICollection<T>.Add (append to tail) --------
        /// <summary>
        /// Appends an item to the tail of the list. Implements <c>ICollection&lt;T&gt;.Add</c>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            AddLast(item);
        }

        // -------- RemoveFirst --------
        /// <summary>
        /// Removes and returns the first element of the list.
        /// Throws <see cref="InvalidOperationException"/> if the list is empty.
        /// </summary>
        /// <returns>The removed element.</returns>
        public T RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("List is empty.");
            var value = Head.Value;
            Head = Head.Next;
            if (Head == null) Tail = null;
            Count--;
            return value;
        }

        // -------- RemoveLast (O(n) for singly list) --------
        /// <summary>
        /// Removes and returns the last element of the list. Operation is O(n) for a singly linked list.
        /// Throws <see cref="InvalidOperationException"/> if the list is empty.
        /// </summary>
        /// <returns>The removed element.</returns>
        public T RemoveLast()
        {
            if (Head == null) throw new InvalidOperationException("List is empty.");

            if (Head == Tail) // single element
            {
                var only = Head.Value;
                Head = null;
                Tail = null;
                Count = 0;
                return only;
            }

            // walk to node before tail
            var prev = Head;
            while (prev.Next != Tail)
            {
                prev = prev.Next;
            }

            var val = Tail.Value;
            prev.Next = null;
            Tail = prev;
            Count--;
            return val;
        }

        // -------- Remove(item): remove first occurrence --------
        /// <summary>
        /// Removes the first occurrence of the specified item from the list.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if an element was removed; otherwise false.</returns>
        public bool Remove(T item)
        {
            if (Head == null) return false;

            if (EqualityComparer<T>.Default.Equals(Head.Value, item))
            {
                Head = Head.Next;
                if (Head == null) Tail = null;
                Count--;
                return true;
            }

            var prev = Head;
            var curr = Head.Next;
            while (curr != null)
            {
                if (EqualityComparer<T>.Default.Equals(curr.Value, item))
                {
                    prev.Next = curr.Next;
                    if (curr.Next == null) Tail = prev; // removed tail
                    Count--;
                    return true;
                }
                prev = curr;
                curr = curr.Next;
            }
            return false;
        }

        // -------- Contains --------
        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns>True if the item exists in the list; otherwise false.</returns>
        public bool Contains(T item)
        {
            var n = Head;
            while (n != null)
            {
                if (EqualityComparer<T>.Default.Equals(n.Value, item)) return true;
                n = n.Next;
            }
            return false;
        }

        // -------- CopyTo --------
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

        // -------- Clear --------
        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // -------- Enumerators (foreach) --------
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

        /// <summary>
        /// Returns the zero-based index of the first occurrence of the specified item, or -1 if not found.
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns>Index of the item if found; otherwise -1.</returns>
        public int IndexOf(T item)
        {
            int idx = 0;
            var n = Head;
            var cmp = EqualityComparer<T>.Default;
            while (n != null)
            {
                if (cmp.Equals(n.Value, item)) return idx;
                n = n.Next;
                idx++;
            }
            return -1;
        }

    }
}
