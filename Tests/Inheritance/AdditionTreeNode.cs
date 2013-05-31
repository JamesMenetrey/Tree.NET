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
    /// Defines an addition node.
    /// </summary>
    public class AdditionTreeNode : OperatorTreeNode
    {
        /// <summary>
        /// Initializes a new <see cref="AdditionTreeNode"/>.
        /// </summary>
        public AdditionTreeNode()
        {
            Computation = (nodeValue, result) => result + nodeValue;
        }
    }
}
