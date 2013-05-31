/*
* Tree.NET
* https://github.com/ZenLulz/Tree.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-31
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Inheritance;

namespace Tests
{
    [TestClass]
    public class InheritanceTests
    {
        /// <summary>
        /// Represents the equation: 4 + 6 = 10.
        /// </summary>
        [TestMethod]
        public void Addition()
        {
            var tree = new AdditionTreeNode
                {
                    new NumberTreeNode(4),
                    new NumberTreeNode(6)
                };

            Assert.AreEqual(10, tree.Compute());
        }
        /// <summary>
        /// Represents the equation: (4 + 6) - 9 = 1.
        /// </summary>
        [TestMethod]
        public void AdditionAndSubstraction()
        {
            var tree = new SubstrationTreeNode
                {
                    new AdditionTreeNode
                        {
                            new NumberTreeNode(4),
                            new NumberTreeNode(6)
                        },
                    new NumberTreeNode(9)
                };

            Assert.AreEqual(1, tree.Compute());
        }
        /// <summary>
        /// Represents the equation: (2 * 2 * 5) / (5 * 2) = 2.
        /// </summary>
        [TestMethod]
        public void MultiplicationAndDivision()
        {
            var tree = new DivisionTreeNode
                {
                    new MultiplicationTreeNode
                        {
                            new NumberTreeNode(2),
                            new NumberTreeNode(2),
                            new NumberTreeNode(5)
                        },
                    new MultiplicationTreeNode
                        {
                            new NumberTreeNode(5),
                            new NumberTreeNode(2)
                        }
                };

            Assert.AreEqual(2, tree.Compute());
        }
        /// <summary>
        /// ((5 * (2 * 3)) + 10) - ((10 / 2) + 5) = 30
        /// </summary>
        [TestMethod]
        public void AllOperators()
        {
            var tree = new SubstrationTreeNode
                {
                    new AdditionTreeNode
                        {
                            new MultiplicationTreeNode
                                {
                                    new NumberTreeNode(5),
                                    new MultiplicationTreeNode
                                        {
                                            new NumberTreeNode(2),
                                            new NumberTreeNode(3)
                                        }
                                },
                            new NumberTreeNode(10)
                        },
                    new AdditionTreeNode
                        {
                            new DivisionTreeNode
                                {
                                    new NumberTreeNode(10),
                                    new NumberTreeNode(2)
                                },
                            new NumberTreeNode(5)
                        }
                };

            Assert.AreEqual(30, tree.Compute());
        }
    }
}
