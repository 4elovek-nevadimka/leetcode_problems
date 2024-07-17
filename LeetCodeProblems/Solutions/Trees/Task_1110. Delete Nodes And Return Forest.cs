namespace Solutions.Trees
{
    internal class Task_1110
    {
        // #Array #Hash Table #Tree #Depth-First Search #Binary Tree

        private readonly HashSet<int> _deleteHash = [];

        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {            
            foreach (var node in to_delete)
                _deleteHash.Add(node);

            var forest = new List<TreeNode>();
            root = TraverseTree(root, forest);
            if (root != null)
                forest.Add(root);

            return forest;
        }

        private TreeNode TraverseTree(TreeNode node, IList<TreeNode> forest)
        {
            if (node == null)
                return null;

            node.left = TraverseTree(node.left, forest);
            node.right = TraverseTree(node.right, forest);

            if (_deleteHash.Contains(node.val))
            {
                if (node.left != null)
                    forest.Add(node.left);

                if (node.right != null)
                    forest.Add(node.right);

                return null;
            }

            return node;
        }
    }
}
