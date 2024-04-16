namespace Solutions.Trees
{
    internal class Task_0623
    {
        // #Tree #Depth-First Search #Breadth-First Search #Binary Tree

        public void Run()
        {
            // AddOneRow(, 1, 3);
        }

        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            return Solution1(root, val, depth);
        }

        private TreeNode Solution1(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                return new TreeNode(val, root);
            }
            else
            {
                var curDepth = 1;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (curDepth < depth - 1)
                {
                    var neighbors = queue.Count;
                    while (neighbors > 0)
                    {
                        var node = queue.Dequeue();
                        if (node.left != null)
                            queue.Enqueue(node.left);
                        if (node.right != null)
                            queue.Enqueue(node.right);
                        neighbors--;
                    }
                    curDepth++;
                }

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    var newLeft = new TreeNode(val, node.left);
                    var newRight = new TreeNode(val, null, node.right);
                    node.left = newLeft;
                    node.right = newRight;
                }

                return root;
            }
        }

        private TreeNode Solution2(TreeNode root, int val, int depth)
        {
            if (depth == 1)
                return new TreeNode(val, root);
            else
                Traverse(root, 1, val, depth);

            return root;
        }

        private void Traverse(TreeNode node, int curDepth, int val, int depth)
        {
            if (node == null)
                return;

            if (curDepth == depth - 1)
            {
                var newLeft = new TreeNode(val, node.left);
                var newRight = new TreeNode(val, null, node.right);
                node.left = newLeft;
                node.right = newRight;
                return;
            }

            Traverse(node.left, curDepth + 1, val, depth);
            Traverse(node.right, curDepth + 1, val, depth);
        }
    }
}
