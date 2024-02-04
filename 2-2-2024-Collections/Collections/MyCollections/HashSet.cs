using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a generic set data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the set.</typeparam>
    public class HashSet<T> {

        private Dictionary<T, String> dictionary;
        private const String PRESENT = "PRESENT";

        /// <summary>
        /// Gets the number of elements contained in the HashSet.
        /// </summary>
        public int Count => dictionary.Count;

        /// <summary>
        /// Initializes a new instance of the HashSet class.
        /// </summary>
        public HashSet() { 
            dictionary = new Dictionary<T, String>();
        }

        /// <summary>
        /// Adds an element to the HashSet.
        /// </summary>
        /// <param name="item">The element to add to the HashSet.</param>
        /// <returns>true if the element is added to the HashSet; otherwise, false if the element is already present.</returns>
        public bool Add(T item) {
            if(dictionary.Contains(item))
                return false;
            dictionary.Add(item, PRESENT);
            return true;
        }

        /// <summary>
        /// Removes the specified element from the HashSet.
        /// </summary>
        /// <param name="item">The element to remove from the HashSet.</param>
        /// <returns>true if the element is successfully removed; otherwise, false if the element is not found in the HashSet.</returns>
        public bool Remove(T item) {
            return dictionary.Remove(item);
        }

        /// <summary>
        /// Determines whether the HashSet contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate in the HashSet.</param>
        /// <returns>true if the HashSet contains the specified element; otherwise, false.</returns>
        public bool Contains(T item) {
            return dictionary.Contains(item);
        }
    }
}
