using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a generic dictionary data structure.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class Dictionary<TKey, TValue> {
        class Pair {
            public TKey key;
            public TValue value;

            public Pair(TKey key, TValue value) {
                this.key = key;
                this.value = value;
            }
        }

        private ArrayList list;
        private int capacity = 30;
        private float increaseFactor = 0.8f;
        private float loadFactor = 0.7f;
        private int count = 0;

        /// <summary>
        /// Gets the number of key-value pairs contained in the Dictionary.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Initializes a new instance of the Dictionary class.
        /// </summary>
        public Dictionary() {
            list = new ArrayList();
            for (int i = 0; i < capacity; i++) {
                list.Add(new DoublyLinkedList<Pair>());
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key.</returns>
        public TValue this[TKey key] {
            get {
                TValue value;
                if (TryGetValue(key, out value)) {
                    return value;
                }
                return default(TValue);
            }
            set {
                Add(key, value);
            }
        }

        /// <summary>
        /// Removes the value associated with the specified key from the Dictionary.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        /// <returns>true if the value is successfully removed; otherwise, false.</returns>
        public bool Remove(TKey key) {
            int index = GetIndex(key, capacity);
            DoublyLinkedList<Pair> linkedList = (DoublyLinkedList<Pair>)list[index];
            Node<Pair> current = linkedList.GetHeadNode();
            while (current != null) {
                if (current.data.key.Equals(key)) {
                    linkedList.Remove(current.data);
                    count++;
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.</param>
        /// <returns>true if the Dictionary contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out TValue value) {
            int index = GetIndex(key, capacity);
            DoublyLinkedList<Pair> linkedList = (DoublyLinkedList<Pair>)list[index];
            Node<Pair> current = linkedList.GetHeadNode();
            while (current != null) {
                if (current.data.key.Equals(key)) {
                    value = current.data.value;
                    return true;
                }
                current = current.next;
            }
            value = default(TValue);
            return false;
        }

        private int GetIndex(TKey key,int capacity) {
            int hashCode = key.GetHashCode();
            int index = Math.Abs(hashCode) % capacity;
            return index;
        }

        private Pair FindPair(TKey key) {
            int index = GetIndex(key,capacity);
            DoublyLinkedList<Pair> linkedList = (DoublyLinkedList<Pair>)list[index];
            Node<Pair> current = linkedList.GetHeadNode();
            while (current != null) {
                if (current.data.key.Equals(key)) {
                    return current.data;
                }
                current = current.next;
            }
            return null;
        }

        /// <summary>
        /// Adds the specified key and value to the Dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(TKey key, TValue value) {
            Pair pair = FindPair(key);
            if (pair != null) {
                pair.value = value;
                return;
            }
            int index = GetIndex(key, capacity);
            DoublyLinkedList<Pair> linkedList = (DoublyLinkedList<Pair>)list[index];
            linkedList.AddLast(new Pair(key, value));
            count++;
            if(RequiredToIncreaseInMapSize()) ThenIncreaseSize();
        }

        private bool RequiredToIncreaseInMapSize() {
            float currentLoadFactor = (float)count / (float)capacity;
            return currentLoadFactor > loadFactor;
        }

        private void ThenIncreaseSize() {
            int newCapacity = (int)(increaseFactor * capacity);
            ArrayList newArrayList = new ArrayList(newCapacity);
            for(int i = 0;i< newCapacity; i++) 
                newArrayList.Add(new DoublyLinkedList<Pair>());
            for(int i = 0;i<capacity;i++) {
                DoublyLinkedList<Pair> traverseList = (DoublyLinkedList<Pair>)list[i];
                Node<Pair> head = traverseList.GetHeadNode();
                while(head != null) {
                    int index = GetIndex(head.data.key, newCapacity);
                    ((DoublyLinkedList<Pair>)newArrayList[index]).AddLast(head.data);
                    head = head.next;
                }
            }
            capacity = newCapacity;
            list = newArrayList;
        }

        /// <summary>
        /// Determines whether the Dictionary contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the Dictionary.</param>
        /// <returns>true if the Dictionary contains an element with the specified key; otherwise, false.</returns>
        public bool Contains(TKey key) {
            return FindPair(key) != null;
        }
    }
}
