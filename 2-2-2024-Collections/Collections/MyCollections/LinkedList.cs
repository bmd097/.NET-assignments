using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a linked list data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the linked list.</typeparam>
    public class LinkedList<T> : IMyList<T> {

        private DoublyLinkedList<T> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedList{T}"/> class.
        /// </summary>
        public LinkedList() {
            list = new DoublyLinkedList<T>();
        }

        /// <summary>
        /// Gets the number of elements contained in the linked list.
        /// </summary>
        public int Count => list.Count;

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="Exception">Thrown when the element at the specified index is not found.</exception>
        public T this[int index] {
            get {
                T value;
                if (list.GetAt(index, out value)) {
                    return value;
                }
                throw new Exception("Not Found");
            }
            set {
                throw new Exception("Not Supported!");
            }
        }

        /// <summary>
        /// Adds an element to the end of the linked list.
        /// </summary>
        /// <param name="value">The element to add.</param>
        /// <returns>The index at which the element was added.</returns>
        public int Add(T value) {
            list.AddLast(value);
            return list.Count - 1;
        }

        /// <summary>
        /// Removes all elements from the linked list.
        /// </summary>
        public void Clear() {
            list = new DoublyLinkedList<T>();
        }

        /// <summary>
        /// Determines whether the linked list contains a specific element.
        /// </summary>
        /// <param name="value">The element to locate in the linked list.</param>
        /// <returns><c>true</c> if the element is found; otherwise, <c>false</c>.</returns>
        public bool Contains(T value) {
            return list.IndexOf(value) != -1;
        }

        /// <summary>
        /// Searches for the specified element and returns the zero-based index of the first occurrence within the entire linked list.
        /// </summary>
        /// <param name="value">The element to locate in the linked list.</param>
        /// <returns>The zero-based index of the first occurrence of the element within the entire linked list, if found; otherwise, -1.</returns>
        public int IndexOf(T value) {
            return list.IndexOf(value);
        }

        /// <summary>
        /// Inserts an element into the linked list at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the element should be inserted.</param>
        /// <param name="value">The element to insert.</param>
        public void Insert(int index, T value) {
            list.Add(index, value);
        }

        /// <summary>
        /// Removes the first occurrence of a specific element from the linked list.
        /// </summary>
        /// <param name="value">The element to remove.</param>
        public void Remove(T value) {
            list.Remove(value);
        }

        /// <summary>
        /// Removes the element at the specified index of the linked list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="Exception">Thrown when the element at the specified index is not found.</exception>
        public void RemoveAt(int index) {
            T value;
            if (list.RemoveAt(index, out value)) {
                return;
            }
            throw new Exception("Not Found");
        }

        /// <summary>
        /// Returns a hash code for the linked list.
        /// </summary>
        /// <returns>A hash code for the linked list.</returns>
        public override int GetHashCode() {
            return list.PrintList().GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the linked list.
        /// </summary>
        /// <param name="obj">The object to compare with the current linked list.</param>
        /// <returns><c>true</c> if the specified object is equal to the linked list; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            LinkedList<T> other = (LinkedList<T>)obj;
            if (Count != other.Count) return false;
            return list.PrintList().Equals(other.list.PrintList());
        }
    }
}
