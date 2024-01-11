namespace Solutions.Trees
{
    internal class Task_1026
    {
        public int MaxAncestorDiff(TreeNode root)
        {
            return Traverse(root, root.val, root.val);
        }

        private int Traverse(TreeNode node, int min, int max)
        {
            if (node == null)
                return 0;

            var current = 
                Math.Max(Math.Abs(node.val - min), Math.Abs(node.val - max));

            min = Math.Min(node.val, min);
            max = Math.Max(node.val, max);

            var left = Traverse(node.left, min, max);
            var rigth = Traverse(node.right, min, max);

            return Math.Max(current, Math.Max(left, rigth));
        }
    }
}
