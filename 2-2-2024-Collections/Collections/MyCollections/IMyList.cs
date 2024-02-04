using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Represents a generic list data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public interface IMyList<T> {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        T this[int index] {
            get;
            set;
        }
        /// <summary>
        /// Adds an element to the list.
        /// </summary>
        /// <param name="value">The element to add to the list.</param>
        /// <returns>The index at which the element has been added.</returns>
        int Add(T value);

        /// <summary>
        /// Determines whether the list contains a specific element.
        /// </summary>
        /// <param name="value">The value to locate in the list.</param>
        /// <returns>true if the value is found in the list; otherwise, false.</returns>
        bool Contains(T value);

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        void Clear();

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire list.
        /// </summary>
        /// <param name="value">The object to locate in the list.</param>
        /// <returns>The zero-based index of the first occurrence of the value within the entire list, if found; otherwise, -1.</returns>
        int IndexOf(T value);

        /// <summary>
        /// Inserts an element into the list at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the element should be inserted.</param>
        /// <param name="value">The element to insert.</param>
        void Insert(int index, T value);

        /// <summary>
        /// Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="value">The object to remove from the list.</param>
        void Remove(T value);

        /// <summary>
        /// Removes the element at the specified index of the list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        void RemoveAt(int index);
    }
}
