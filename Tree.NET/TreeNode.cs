/*
* Tree.NET
* https://github.com/ZenLulz/Tree.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-27
*/

using System.Collections;
using System.Collections.Generic;

namespace Binarysharp.Collections
{
    /// <summary>
    /// An abstract tree node implementation.
    /// </summary>
    /// <typeparam name="T">Corresponding to its own type.</typeparam>
    public abstract class TreeNode<T> : ICollection<T> where T : TreeNode<T>
    {
        #region Fields
        /// <summary>
        /// The list of children of the node.
        /// </summary>
        private readonly List<T> _children;  
        #endregion

        #region Properties
        /// <summary>
        /// Gets the number of children.
        /// </summary>
        public int Count
        {
            get { return _children.Count; }
        }
        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly { get { return false; } }
        /// <summary>
        /// Gets a value indicating whether the node is the root of the tree.
        /// </summary>
        public bool IsRoot
        {
            get { return Parent == null; }
        }
        /// <summary>
        /// The parent of the node.
        /// </summary>
        public T Parent { get; protected set; }
        /// <summary>
        /// Gets a child at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The child.</returns>
        public T this[int index]
        {
            get { return _children[index]; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a tree node.
        /// </summary>
        /// <param name="nodes">The child nodes.</param>
        protected TreeNode(params T[] nodes)
        {
            // Initialize the children list
            _children = new List<T>();
            // Add the children
            AddRange(nodes);
        }
        #endregion

        #region Methods
        #region Add
        /// <summary>
        /// Adds a child.
        /// </summary>
        /// <param name="node">The child.</param>
        public void Add(T node)
        {
            // Add the node to the list
            _children.Add(node);
            // Set the parent
            node.Parent = (T)this;
        }
        #endregion
        #region AddRange
        /// <summary>
        /// Adds an array of children.
        /// </summary>
        /// <param name="nodes">The array of children.</param>
        public void AddRange(params T[] nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }
        #endregion
        #region Clear
        /// <summary>
        /// Removes all children.
        /// </summary>
        public void Clear()
        {
            _children.Clear();
        }
        #endregion
        #region Contains
        /// <summary>
        /// Determines whether the collection contains a specific child.
        /// </summary>
        /// <param name="node">The child.</param>
        /// <returns><c>True</c> if the node is found in the children collection, otherwise, <c>false</c>.</returns>
        public bool Contains(T node)
        {
            return _children.Contains(node);
        }
        #endregion
        #region CopyTo
        /// <summary>
        /// Copies the children to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the children copied from the tree. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
        }
        #endregion
        #region GetEnumerator
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{TreeNode}"/> that can be used to iterate through the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _children.GetEnumerator();
        }
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="IEnumerator"/> that can be used to iterate through the collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region Remove
        /// <summary>
        /// Removes a child.
        /// </summary>
        /// <param name="node">The child.</param>
        public bool Remove(T node)
        {
            // Unset the parent link
            node.Parent = null;
            // Remove the child
            return _children.Remove(node);
        }
        #endregion
        #endregion
    }
}
