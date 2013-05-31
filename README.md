Tree.NET
========

A simplistic Tree data structure implementation in .NET.

Static implementation using parameters
--------------------------------------

A tree can be statically implemented with the parameter `nodes` of the constructor like the following.

	var tree =
		new ValueTreeNode<string>("Root",
			new ValueTreeNode<string>("1. Article",
				new ValueTreeNode<string>("1.1 Comment"),
				new ValueTreeNode<string>("1.2 Comment")),
			new ValueTreeNode<string>("2. Article",
				new ValueTreeNode<string>("2.1 Comment"),
				new ValueTreeNode<string>("2.2 Comment",
					new ValueTreeNode<string>("2.2.1 Comment's comment !")
		)));
			
This code corresponds to the result below.

	Root
		1. Article
			1.1 Comment
			1.2 Comment
		2. Article
			2.1 Comment
			2.2 Comment
				2.2.1 Comment's comment !

Static implementation using collection initializer
--------------------------------------------------

A tree can be statically implemented with the use of the collection initializer like the following.

	var tree = new ValueTreeNode<string>("Operating Systems")
	   {
		   new ValueTreeNode<string>("Linux")
		   {
									 new ValueTreeNode<string>("Ubuntu"),
									 new ValueTreeNode<string>("Fedora"),
									 new ValueTreeNode<string>("CentOS")
		   }, 
		   new ValueTreeNode<string>("Windows")
		   {
									 new ValueTreeNode<string>("Windows 7"),
									 new ValueTreeNode<string>("Windows XP")
									 {
															   new ValueTreeNode<string>("Home Edition"),
															   new ValueTreeNode<string>("Professional Edition")
									 }
										 
		   }
	   };
   
This code corresponds to the result below.

	Operating Systems
		Linux
			Ubuntu
			Fedora
			CentOS
		Windows
			Windows 7
			Windows XP
				Home Edition
				Professional Edition
			
Dynamic implementation
----------------------

A tree can be dynamically implemented like the following.

	var tree = new ValueTreeNode<string>("Operating Systems");

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
		
Advanced implementation with inheritance
---------------------------------------

It's possible to inherit from the class `TreeNode<T>` to increase the performance and the readability of your code. In the following example, a tree is used to represent an equation.

	// Represents the equation: (2 * 2 * 5) / (5 * 2).
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

See the source file `InheritanceTests.cs` in the Test Unit for more information.

Author
------

Jämes Ménétrey ~ ZenLulz

See the file LICENSE for more information regarding your rights.