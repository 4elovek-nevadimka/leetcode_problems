namespace Solutions.Trees
{
    internal class Task_1325
    {
        // #Tree #Depth-First Search #Binary Tree

        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null) return null;

            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            if (root.left == null && root.right == null && root.val == target)
                return null;

            return root;
        }
    }
}
