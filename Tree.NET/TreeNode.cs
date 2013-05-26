/*
* DoublyLinkedList.NET
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
    /// Represents a generic tree node.
    /// </summary>
    public class TreeNode<T> : ICollection<TreeNode<T>>
    {
        #region Fields
        /// <summary>
        /// The list of children of the node.
        /// </summary>
        private readonly List<TreeNode<T>> _children;  
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
        /// Gets if the node is the root of the tree.
        /// </summary>
        public bool IsRoot
        {
            get { return Parent == null; }
        }
        /// <summary>
        /// The parent of the node.
        /// </summary>
        public TreeNode<T> Parent { get; protected set; }
        /// <summary>
        /// Gets a child at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The child.</returns>
        public TreeNode<T> this[int index]
        {
            get { return _children[index]; }
        }
        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a tree node.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="nodes">The child nodes.</param>
        public TreeNode(T value, params TreeNode<T>[] nodes)
        {
            // Set the value
            Value = value;
            // Initialize the children list
            _children = new List<TreeNode<T>>();
            // Add the children
            AddRange(nodes);
        }
        #endregion

        #region Methods
        #region Add
        /// <summary>
        /// Adds a node.
        /// </summary>
        /// <param name="node">The node.</param>
        public void Add(TreeNode<T> node)
        {
            // Add the node to the list
            _children.Add(node);
            // Set the parent
            node.Parent = this;
        }
        #endregion
        #region AddRange
        /// <summary>
        /// Adds an array of nodes.
        /// </summary>
        /// <param name="nodes">The array of nodes.</param>
        public void AddRange(params TreeNode<T>[] nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }
        #endregion
        #region Clear
        /// <summary>
        /// Removes all nodes.
        /// </summary>
        public void Clear()
        {
            _children.Clear();
        }
        #endregion
        #region Contains
        /// <summary>
        /// Determines whether the collection contains a specific node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>True</c> if item is found in the children, otherwise, <c>false</c>.</returns>
        public bool Contains(TreeNode<T> node)
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
        public void CopyTo(TreeNode<T>[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
        }
        #endregion
        #region GetEnumerator
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{TreeNode}"/> that can be used to iterate through the collection</returns>
        public IEnumerator<TreeNode<T>> GetEnumerator()
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
        /// Removes a node.
        /// </summary>
        /// <param name="node">The node.</param>
        public bool Remove(TreeNode<T> node)
        {
            return _children.Remove(node);
        }
        #endregion
        #region ToString
        /// <summary>
        /// Returns a string that represents the current node.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Value = {0}", Value);
        }
        #endregion
        #endregion
    }
}
