namespace Solutions.Trees
{
    internal class Task_0404
    {
        // #Tree #Depth-First Search #Breadth-First Search #Binary Tree

        public int SumOfLeftLeaves(TreeNode root)
        {
            return SumOfLeftLeavesTraverse(root, false);
        }

        private int SumOfLeftLeavesTraverse(TreeNode node, bool isLeft)
        {
            if (node == null) return 0;

            if (node.left == null && node.right == null && isLeft)
                return node.val;

            var leftSum = SumOfLeftLeavesTraverse(node.left, true);
            var rightSum = SumOfLeftLeavesTraverse(node.right, false);

            return leftSum + rightSum;
        }
    }
}
