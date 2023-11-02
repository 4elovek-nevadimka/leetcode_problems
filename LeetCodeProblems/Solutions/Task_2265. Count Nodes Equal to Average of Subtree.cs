namespace Solutions
{
    internal class Task_2265
    {
        private int avgCounter = 0;

        public int AverageOfSubtree(TreeNode root) {
            Traverse(root);
            return avgCounter;
        }

        private (int nodes, int sum) Traverse(TreeNode node)
        {
            if (node == null) return (0, 0);

            var left = Traverse(node.left);

            var right = Traverse(node.right);

            var nodes = left.nodes + right.nodes + 1;
            var sum = left.sum + right.sum + node.val;

            if (sum / nodes == node.val) avgCounter++;
            
            return (nodes, sum);
        }
    }
}
