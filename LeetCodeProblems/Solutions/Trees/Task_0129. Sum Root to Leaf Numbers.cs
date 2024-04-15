namespace Solutions.Trees
{
    internal class Task_0129
    {
        // #Tree #Depth-First Search #Binary Tree

        public int SumNumbers(TreeNode root)
        {
            return SumNumbersTraverse(root, root.val);
        }

        private int SumNumbersTraverse(TreeNode node, int value)
        {
            if (node == null)
                return 0;

            var curValue = value * 10 + node.val;

            if (node.left == null && node.right == null)
            {
                return curValue;
            }

            var left = SumNumbersTraverse(node.left, curValue);
            var right = SumNumbersTraverse(node.right, curValue);

            return left + right;
        }
    }
}
