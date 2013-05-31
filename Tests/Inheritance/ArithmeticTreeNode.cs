/*
* Tree.NET
* https://github.com/ZenLulz/Tree.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-31
*/

using Binarysharp.Collections;

namespace Tests.Inheritance
{
    /// <summary>
    /// Implementation of an arithmetic tree node.
    /// </summary>
    public abstract class ArithmeticTreeNode : TreeNode<ArithmeticTreeNode>
    {
        /// <summary>
        /// The function that computes all the operations of the child nodes.
        /// </summary>
        /// <returns>The result.</returns>
        public abstract float Compute();
    }
}
