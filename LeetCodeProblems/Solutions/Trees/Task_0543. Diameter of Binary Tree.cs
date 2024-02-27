namespace Solutions.Trees
{
    internal class Task_0543
    {
        // #Tree #Depth-First Search #Binary Tree

        public int DiameterOfBinaryTree(TreeNode root)
        {
            return TraverseTree(root).Diameter;
        }

        private (int Level, int Diameter) TraverseTree(TreeNode node)
        {
            if (node == null)
                return (0, 0);

            var left = TraverseTree(node.left);
            var right = TraverseTree(node.right);

            var level = Math.Max(left.Level, right.Level);
            var diameter = Math.Max(left.Diameter, right.Diameter);

            diameter = Math.Max(diameter, left.Level + right.Level);

            return (level, diameter);
        }
    }
}
