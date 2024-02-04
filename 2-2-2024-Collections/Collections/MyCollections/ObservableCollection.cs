using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    public enum OperationType {
        ADD, REMOVE
    }
    /// <summary>
    /// Represents a collection that provides notifications when its elements are added or removed.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class ObservableCollection<T> {

        private DoublyLinkedList<T> _list;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableCollection{T}"/> class.
        /// </summary>
        public ObservableCollection() {
            _list = new DoublyLinkedList<T>();
        }

        /// <summary>
        /// Represents the method that will handle the collection changed event.
        /// </summary>
        /// <param name="type">The type of operation performed on the collection.</param>
        /// <param name="affected">The elements affected by the operation.</param>
        public delegate void OperationCallback(OperationType type, LinkedList<T> affected);
        /// <summary>
        /// Occurs when the collection has changed.
        /// </summary>
        public event OperationCallback CollectionChanged;

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item) {
            _list.AddLast(item);
            LinkedList<T> list = new LinkedList<T>();
            list.Add(item);
            CollectionChanged(OperationType.ADD,list);
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns><c>true</c> if the item was successfully removed; otherwise, <c>false</c>.</returns>
        public bool Remove(T item) {
            _list.Remove(item);
            LinkedList<T> list = new LinkedList<T>();
            list.Add(item);
            CollectionChanged(OperationType.REMOVE, list);
            return true;
        }
        
    }
}
