/*
* Tree.NET
* https://github.com/ZenLulz/Tree.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-27
*/

namespace Binarysharp.Collections
{
    /// <summary>
    /// A generic tree node implementation.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class ValueTreeNode<T> : TreeNode<ValueTreeNode<T>>
    {
        #region Properties
        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes an tree node.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="nodes">The array of child nodes.</param>
        public ValueTreeNode(T value, params ValueTreeNode<T>[] nodes) : base(nodes)
        {
            // Store the value
            Value = value;
        }
        #endregion

        #region Methods
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
