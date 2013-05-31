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
    /// Defines an substraction node.
    /// </summary>
    public class SubstrationTreeNode : OperatorTreeNode
    {
        /// <summary>
        /// Initializes a new <see cref="SubstrationTreeNode"/>.
        /// </summary>
        public SubstrationTreeNode()
        {
            Computation = (nodeValue, result) => result - nodeValue;
        }
    }
}
