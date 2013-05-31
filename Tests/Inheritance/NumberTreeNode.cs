/*
* Tree.NET
* https://github.com/ZenLulz/Tree.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-31
*/

namespace Tests.Inheritance
{
    /// <summary>
    /// Defines a number tree node.
    /// </summary>
    public class NumberTreeNode : ArithmeticTreeNode
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        public float Value { get; private set; }

        /// <summary>
        /// The function that computes all the operations of the child nodes.
        /// </summary>
        /// <returns>The result.</returns>
        public override float Compute()
        {
            return Value;
        }

        /// <summary>
        /// Initializes a new <see cref="NumberTreeNode"/>.
        /// </summary>
        /// <param name="value"></param>
        public NumberTreeNode(float value)
        {
            Value = value;
        }
    }
}
