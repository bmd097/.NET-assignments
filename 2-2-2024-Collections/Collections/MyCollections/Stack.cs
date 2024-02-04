using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a generic stack data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public class Stack<T> {
        private DoublyLinkedList<T> list;

        /// <summary>
        /// Initializes a new instance of the Stack class.
        /// </summary>
        public Stack() {
            list = new DoublyLinkedList<T>();
        }

        /// <summary>
        /// Gets the number of elements contained in the Stack.
        /// </summary>
        public int Count => list.Count;

        /// <summary>
        /// Returns the object at the top of the Stack without removing it.
        /// </summary>
        /// <returns>The object at the top of the Stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the Stack is empty.</exception>
        public T Peek() {
            T value;
            if (list.GetLast(out value)) {
                return value;
            }
            throw new InvalidOperationException("Stack is empty.");
        }

        /// <summary>
        /// Removes and returns the object at the top of the Stack.
        /// </summary>
        /// <returns>The object removed from the top of the Stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the Stack is empty.</exception>
        public T Pop() {
            T value;
            if (list.RemoveLast(out value)) {
                return value;
            }
            throw new InvalidOperationException("Stack is empty.");
        }

        /// <summary>
        /// Inserts an object at the top of the Stack.
        /// </summary>
        /// <param name="item">The object to push onto the Stack.</param>
        public void Push(T item) {
            list.AddLast(item);
        }

        /// <summary>
        /// Determines whether an element is in the Stack.
        /// </summary>
        /// <param name="item">The object to locate in the Stack.</param>
        /// <returns>true if the object is found in the Stack; otherwise, false.</returns>
        public bool Contains(T item) {
            if(list.Count == 0) return false;
            Node<T> headPointer = list.GetHeadNode();
            while (headPointer != null) {
                if (headPointer.data.Equals(item)) return true;
                headPointer = headPointer.next; 
            }
            return false;
        }

        /// <summary>
        /// Copies the Stack elements to a new array.
        /// </summary>
        /// <returns>An array containing copies of the elements of the Stack.</returns>
        public T[] ToArray() {
            T[] array = new T[list.Count];
            Node<T> current = list.GetHeadNode();
            int index = 0;
            while (current != null) {
                array[index] = current.data;
                current = current.next;
                index++;
            }
            return array;
        }

        /// <summary>
        /// Returns a string that represents the current Stack.
        /// </summary>
        /// <returns>A string that represents the current Stack.</returns>
        public override String ToString() {
            Node<T> node = list.GetHeadNode();
            StringBuilder stringBuilder = new StringBuilder();
            while(node!= null) {
                stringBuilder.Append(node.data.ToString()+" ");
                node = node.next;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current Stack.
        /// </summary>
        /// <param name="obj">The object to compare with the current Stack.</param>
        /// <returns>true if the specified object is equal to the current Stack; otherwise, false.</returns>
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            Stack<T> otherStack = (Stack<T>)obj;
            if(Count != otherStack.Count) {
                return false;
            }
            return ToString().Equals(otherStack.ToString());
        }

        /// <summary>
        /// Returns the hash code for the current Stack.
        /// </summary>
        /// <returns>A hash code for the current Stack.</returns>
        public override int GetHashCode() {
            int hash = 17;
            Node<T> headPointer = list.GetHeadNode();
            for (int i = 0; i < Count; i++) {
                hash = hash * 7 + ((headPointer.data)?.GetHashCode() ?? 0);
                headPointer = headPointer.next;
            }
            return hash;
        }
    }
}
