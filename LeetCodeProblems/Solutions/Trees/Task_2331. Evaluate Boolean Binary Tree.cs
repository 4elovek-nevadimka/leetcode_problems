namespace Solutions.Trees
{
    // #Tree #Depth-First Search #Binary Tree

    internal class Task_2331
    {
        public bool EvaluateTree(TreeNode root)
        {
            if (root.val == 0) return false;
            else if (root.val == 1) return true;

            var left = EvaluateTree(root.left);
            var right = EvaluateTree(root.right);

            return root.val == 2 ? left || right : left && right;
        }
    }
}
