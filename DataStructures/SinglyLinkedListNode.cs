using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SinglyLinkedListNode<T>
    {

        public T Value { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : "null";
        }

    }
}
