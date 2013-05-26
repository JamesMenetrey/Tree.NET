/*
* DoublyLinkedList.NET
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
        private readonly TreeNode<int> _tree = 
            new TreeNode<int>(0,
                new TreeNode<int>(1,
                    new TreeNode<int>(2),
                    new TreeNode<int>(3)
                    ),
                new TreeNode<int>(4,
                    new TreeNode<int>(5),
                    new TreeNode<int>(6,
                        new TreeNode<int>(7)
                        )
                    )
                );

        [TestMethod]
        public void TraverseChildren()
        {
            Assert.AreEqual(7, _tree[1][1][0].Value);

        }

        [TestMethod]
        public void TraverseParents()
        {
            // Arrange
            var child = _tree[1][1][0];

            // Act
            var root = child.Parent.Parent.Parent;

            // Assert
            Assert.AreEqual(_tree, root);
        }

        /// <summary>
        /// No assert.
        /// </summary>
        [TestMethod]
        public void PrintTree()
        {
            Tools.PrintAllNodes(_tree, 0);
        }

        
    }

    internal static class Tools
    {
        internal static void PrintAllNodes<T>(TreeNode<T> node, uint level)
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
