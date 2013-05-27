/*
* Tree.NET
* https://github.com/ZenLulz/Tree.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-27
*/

using System;
using Binarysharp.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TreeTests
    {
        private readonly ValueTreeNode<int> _treeInt = 
            new ValueTreeNode<int>(0,
                new ValueTreeNode<int>(1,
                    new ValueTreeNode<int>(2),
                    new ValueTreeNode<int>(3)
                    ),
                new ValueTreeNode<int>(4,
                    new ValueTreeNode<int>(5),
                    new ValueTreeNode<int>(6,
                        new ValueTreeNode<int>(7)
                        )
                    )
                );

        private readonly ValueTreeNode<string> _treeString =
            new ValueTreeNode<string>("Root",
                new ValueTreeNode<string>("1. Article",
                    new ValueTreeNode<string>("1.1 Comment"),
                    new ValueTreeNode<string>("1.2 Comment")),
                new ValueTreeNode<string>("2. Article",
                    new ValueTreeNode<string>("2.1 Comment"),
                    new ValueTreeNode<string>("2.2 Comment",
                        new ValueTreeNode<string>("2.2.1 Comment's comment !"))
                ));
            
        [TestMethod]
        public void TraverseChildrenInt()
        {
            Assert.AreEqual(7, _treeInt[1][1][0].Value);

        }

        [TestMethod]
        public void TraverseChildrenString()
        {
            Assert.AreEqual("2.2.1 Comment's comment !", _treeString[1][1][0].Value);
        }

        [TestMethod]
        public void TraverseParentsInt()
        {
            // Arrange
            var child = _treeInt[1][1][0];

            // Act
            var root = child.Parent.Parent.Parent;

            // Assert
            Assert.AreEqual(_treeInt, root);
        }

        [TestMethod]
        public void CollectionInitializerImplementation()
        {
            // Arrange
            var tree = new ValueTreeNode<string>("Operating Systems")
                           {
                               new ValueTreeNode<string>("Linux",
                                                         new ValueTreeNode<string>("Ubuntu"),
                                                         new ValueTreeNode<string>("Fedora"),
                                                         new ValueTreeNode<string>("CentOS")
                                   ),
                               new ValueTreeNode<string>("Windows",
                                                         new ValueTreeNode<string>("Windows 7"),
                                                         new ValueTreeNode<string>("Windows XP",
                                                                                   new ValueTreeNode<string>("Home Edition"),
                                                                                   new ValueTreeNode<string>("Professional Edition")
                                                             ))
                           };

            // Act

            var xp = tree[1][1];
            var root = xp.Parent.Parent;

            // Assert
            Assert.AreEqual("Windows XP", xp.Value);
            Assert.AreEqual(tree, root);
        }

        [TestMethod]
        public void DynamicImplementation()
        {
            // Arrange
            var tree = new ValueTreeNode<string>("Operating Systems");

            // Act
            tree.Add(
                new ValueTreeNode<string>("Linux",
                    new ValueTreeNode<string>("Ubuntu"),
                    new ValueTreeNode<string>("Fedora"),
                    new ValueTreeNode<string>("CentOS")
                ));
            tree.Add(
                new ValueTreeNode<string>("Windows",
                    new ValueTreeNode<string>("Windows 7"),
                    new ValueTreeNode<string>("Windows XP",
                        new ValueTreeNode<string>("Home Edition"),
                        new ValueTreeNode<string>("Professional Edition")
                )));

            var xp = tree[1][1];
            var root = xp.Parent.Parent;

            Tools.PrintAllNodes(tree, 0);

            // Assert
            Assert.AreEqual("Windows XP", xp.Value);
            Assert.AreEqual(tree, root);
        }

        /// <summary>
        /// No assert.
        /// </summary>
        [TestMethod]
        public void PrintTreeInt()
        {
            Tools.PrintAllNodes(_treeInt, 0);
        }

        /// <summary>
        /// No assert.
        /// </summary>
        [TestMethod]
        public void PrintTreeString()
        {
            Tools.PrintAllNodes(_treeString, 0);
        }
    }

    internal static class Tools
    {
        internal static void PrintAllNodes<T>(ValueTreeNode<T> node, uint level)
        {
            for (var i = 0; i < level; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(node.Value);

            foreach (var child in node)
            {
                PrintAllNodes(child, level + 1);
            }
        }
    }
}
