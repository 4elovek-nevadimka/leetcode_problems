namespace Solutions.Trees
{
    internal class Task_0094
    {
        public void Run()
        {
            var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            
            var nodesList = InorderTraversal(root);
            foreach (var node in nodesList)
            {
                Console.WriteLine(node);
            }
        }

        // DFS Solution
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();
            
            var list = new List<int>();
            list.AddRange(InorderTraversal(root.left));

            list.Add(root.val);

            list.AddRange(InorderTraversal(root.right));

            return list;
            
        }

        // Stack Solution
        public IList<int> InorderTraversal2(TreeNode root)
        {
            var list = new List<int>();
            var stack = new Stack<TreeNode>();
            while (stack.Count != 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                    list.Add(root.val);
                    root = root.right;
                }
            }
            return list;
        }
    }
}
