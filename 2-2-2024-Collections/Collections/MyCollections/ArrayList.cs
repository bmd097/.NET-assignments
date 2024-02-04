using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a dynamic array-based list.
    /// </summary>
    /// 
    public class ArrayList : IMyList<object>, IEnumerable<object> {

        private object[] array;
        private int count;
        private int initialCapacity;
        private float increaseFactor = 1.8f;

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public object this[int index] {
            get => array[index]; set {
                if (array[index] == null) {
                    array[index] = value;
                    count++;
                } else array[index] = value;
                if (count == initialCapacity) {
                    ResizeArray();
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of the ArrayList class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of the ArrayList.</param>
        public ArrayList(int capacity) {
            initialCapacity = capacity;
            array = new object[initialCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the ArrayList class with the default initial capacity of 10.
        /// </summary>
        public ArrayList() : this(10) { }

        /// <summary>
        /// Gets the number of elements contained in the ArrayList.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Adds an object to the end of the ArrayList.
        /// </summary>
        /// <param name="value">The object to add to the ArrayList.</param>
        /// <returns>The index at which the object has been added.</returns>
        public int Add(object value) {
            if (count == initialCapacity) {
                ResizeArray();
            }
            array[count] = value;
            count++;
            return count - 1;
        }

        /// <summary>
        /// Determines whether the ArrayList contains a specific value.
        /// </summary>
        /// <param name="value">The value to locate in the ArrayList.</param>
        /// <returns>true if the value is found in the ArrayList; otherwise, false.</returns>
        public bool Contains(object value) {
            for (int i = 0; i < count; i++) {
                if (array[i].Equals(value)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes all elements from the ArrayList.
        /// </summary>
        public void Clear() {
            array = new object[initialCapacity];
            count = 0;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire ArrayList.
        /// </summary>
        /// <param name="value">The object to locate in the ArrayList.</param>
        /// <returns>The zero-based index of the first occurrence of the value within the entire ArrayList, if found; otherwise, -1.</returns>
        public int IndexOf(object value) {
            for (int i = 0; i < count; i++) {
                if (array[i].Equals(value)) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Inserts an element into the ArrayList at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the element should be inserted.</param>
        /// <param name="value">The element to insert.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is less than 0 or greater than the Count.</exception>
        public void Insert(int index, object value) {
            if (index < 0 || index > count) {
                throw new IndexOutOfRangeException();
            }
            if (count == array.Length) {
                ResizeArray();
            }
            for (int i = count; i > index; i--) {
                array[i] = array[i - 1];
            }
            array[index] = value;
            count++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the ArrayList.
        /// </summary>
        /// <param name="value">The object to remove from the ArrayList.</param>
        public void Remove(object value) {
            int index = IndexOf(value);
            if (index != -1) {
                RemoveAt(index);
            }
        }

        /// <summary>
        /// Removes the element at the specified index of the ArrayList.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the Count.</exception>
        public void RemoveAt(int index) {
            if (index < 0 || index >= count) {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < count - 1; i++) {
                array[i] = array[i + 1];
            }
            array[count - 1] = null;
            count--;
        }

        private void ResizeArray() {
            int newCapacity = (int)(array.Length * increaseFactor);
            object[] newArray = new object[newCapacity];
            CopyArray(array, newArray, count);
            array = newArray;
            initialCapacity = newCapacity;
        }

        private void CopyArray(object[] sourceArray, object[] destinationArray, int length) {
            for (int i = 0; i < length; i++) {
                destinationArray[i] = sourceArray[i];
            }
        }

        /// <summary>
        /// Returns a hash code for the ArrayList.
        /// </summary>
        /// <returns>A hash code for the ArrayList.</returns>
        public override int GetHashCode() {
            int hash = 17;
            for (int i = 0; i < count; i++) {
                hash = hash * 7 + (array[i]?.GetHashCode() ?? 0);
            }
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the ArrayList.
        /// </summary>
        /// <param name="obj">The object to compare with the ArrayList.</param>
        /// <returns>true if the specified object is equal to the ArrayList; otherwise, false.</returns>
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            ArrayList other = (ArrayList)obj;
            if (count != other.count) {
                return false;
            }
            for (int i = 0; i < count; i++) {
                if (!Equals(array[i], other.array[i])) {
                    return false;
                }
            }
            return true;
        }

        public class Enumerator : IEnumerator<object> {

            private object[] array;
            int capacity;
            int i;

            public Enumerator(object[] array, int capacity) {
                this.array = array;
                this.capacity = capacity;
                this.i = -1;
            }

            public object Current => this.array[i];

            public void Dispose() { }

            public bool MoveNext() {
                i++;
                if (i >= capacity) return false;
                return true;
            }

            public void Reset() {
                i = -1;
            }
        }

        public IEnumerator<object> GetEnumerator() {
            return new Enumerator(array, initialCapacity);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
