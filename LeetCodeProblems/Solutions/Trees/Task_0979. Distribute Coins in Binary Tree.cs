namespace Solutions.Trees
{
    internal class Task_0979
    {
        // #Tree #Depth-First Search #Binary Tree

        private int _moves = 0;

        public int DistributeCoins(TreeNode root)
        {
            Traverse(root);
            return _moves;
        }

        private int Traverse(TreeNode node)
        {
            if (node == null)
                return 0;

            var left = Traverse(node.left);
            var right = Traverse(node.right);

            _moves += Math.Abs(left) + Math.Abs(right);

            return node.val + left + right - 1;
        }
    }
}
