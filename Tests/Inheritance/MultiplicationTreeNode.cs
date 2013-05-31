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
    /// Defines an multiplication node.
    /// </summary>
    public class MultiplicationTreeNode : OperatorTreeNode
    {
        /// <summary>
        /// Initializes a new <see cref="MultiplicationTreeNode"/>.
        /// </summary>
        public MultiplicationTreeNode()
        {
            Computation = (nodeValue, result) => result * nodeValue;
        }
    }
}
