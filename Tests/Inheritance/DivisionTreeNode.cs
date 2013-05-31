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
    /// Defines an division node.
    /// </summary>
    public class DivisionTreeNode : OperatorTreeNode
    {
        /// <summary>
        /// Initializes a new <see cref="DivisionTreeNode"/>.
        /// </summary>
        public DivisionTreeNode()
        {
            Computation = (nodeValue, result) => result / nodeValue;
        }
    }
}
