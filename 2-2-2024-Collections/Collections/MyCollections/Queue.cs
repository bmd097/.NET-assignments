using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a generic queue data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public class Queue<T> {
        private DoublyLinkedList<T> list;

        /// <summary>
        /// Initializes a new instance of the Queue class.
        /// </summary>
        public Queue() {
            list = new DoublyLinkedList<T>();
        }
        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the Queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the Queue is empty.</exception>
        public T Dequeue() {
            T value;
            if (list.RemoveFirst(out value)) {
                return value;
            }
            throw new InvalidOperationException("Queue is empty.");
        }

        /// <summary>
        /// Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="value">The object to add to the Queue.</param>
        public void Enqueue(T value) {
            list.AddLast(value);
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the Queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the Queue is empty.</exception>
        public T Peek() {
            T value;
            if (list.GetFirst(out value)) {
                return value;
            }
            throw new InvalidOperationException("Queue is empty.");
        }

        /// <summary>
        /// Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="item">The object to locate in the Queue.</param>
        /// <returns>true if the object is found in the Queue; otherwise, false.</returns>
        public bool Contains(T item) {
            Node<T> current = list.GetHeadNode();
            while (current != null) {
                if (current.data.Equals(item)) {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Copies the Queue elements to a new array.
        /// </summary>
        /// <returns>An array containing copies of the elements of the Queue.</returns>
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
        /// Gets the number of elements contained in the Queue.
        /// </summary>
        public int Count => list.Count;

        /// <summary>
        /// Determines whether the specified object is equal to the current Queue.
        /// </summary>
        /// <param name="obj">The object to compare with the current Queue.</param>
        /// <returns>true if the specified object is equal to the current Queue; otherwise, false.</returns>
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            Stack<T> otherStack = (Stack<T>)obj;
            if (Count != otherStack.Count) {
                return false;
            }
            return ToString().Equals(otherStack.ToString());
        }

        /// <summary>
        /// Returns the hash code for the current Queue.
        /// </summary>
        /// <returns>A hash code for the current Queue.</returns>
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
