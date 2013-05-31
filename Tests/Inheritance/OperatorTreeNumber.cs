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
    /// The delegate for the computation of each node.
    /// </summary>
    /// <param name="nodeValue">The current node value.</param>
    /// <param name="result">The result value.</param>
    /// <returns>The new result value.</returns>
    public delegate float ComputationDelegate(float nodeValue, float result);

    /// <summary>
    /// Define an operator tree node.
    /// </summary>
    public abstract class OperatorTreeNode : ArithmeticTreeNode
    {
        /// <summary>
        /// The delegate that describes how the node must compute its child nodes.
        /// </summary>
        protected ComputationDelegate Computation;

        /// <summary>
        /// The function that computes all the operations of the child nodes.
        /// </summary>
        /// <returns>The result.</returns>
        public override float Compute()
        {
            // Define the result as a nullable float
            float? result = null;

            // For each child nodes
            foreach (var child in this)
            {
                // If the result is not defined yet
                if (!result.HasValue)
                {
                    // Set the result with the first node
                    result = child.Compute();
                    continue;
                }

                result = Computation(child.Compute(), result.Value);
            }

            // Return the result
            return result.HasValue ? result.Value : 0;
        }
    }
}
