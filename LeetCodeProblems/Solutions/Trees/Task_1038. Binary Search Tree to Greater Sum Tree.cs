namespace Solutions.Trees
{
    internal class Task_1038
    {
        // #Tree #Depth-First Search #Binary Search Tree #Binary Tree

        public void Run()
        {
            var root = TreeNodeGenerator.Generate(
                [4, 1, 6, 0, 2, 5, 7, null, null, null, 3, null, null, null, 8]);
            Console.WriteLine(BstToGst(root));
        }

        public TreeNode BstToGst(TreeNode root)
        {
            BstToGstHelper(root, 0);

            return root;
        }

        private TreeNode BstToGstHelper(TreeNode node, int val)
        {
            if (node.right != null)
                node.val += BstToGstHelper(node.right, val).val;
            else
                node.val += val;

            Console.WriteLine(node.val);

            if (node.left != null)
                return BstToGstHelper(node.left, node.val);

            return node;
        }
    }
}
