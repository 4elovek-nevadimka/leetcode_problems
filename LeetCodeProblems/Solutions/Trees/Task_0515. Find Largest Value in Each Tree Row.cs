namespace Solutions.Trees
{
    public class Task_0515
    {
        public void Run()
        {

        }

        public IList<int> LargestValues(TreeNode root)
        {
            return Solution2(root);
        }

        private IList<int> Solution2(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var largestValues = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentLevelMax = int.MinValue;
                var nodesOnLevel = queue.Count;

                for (var i = 0; i < nodesOnLevel; i++)
                {
                    var node = queue.Dequeue();
                    currentLevelMax = Math.Max(currentLevelMax, node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                }
                largestValues.Add(currentLevelMax);
            }
            return largestValues;
        }

        private IList<int> Solution1(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var largestValues = new List<int> { root.val };

            var nextLevelNodes = new Queue<TreeNode>();
            if (root.left != null)
                nextLevelNodes.Enqueue(root.left);
            if (root.right != null)
                nextLevelNodes.Enqueue(root.right);

            if (nextLevelNodes.Count > 0)
                BFS(largestValues, nextLevelNodes);

            return largestValues;
        }

        private void BFS(IList<int> largestValues, Queue<TreeNode> currentLevelNodes)
        {
            var currentLevelMax = int.MinValue;
            var nextLevelNodes = new Queue<TreeNode>();

            while (currentLevelNodes.Count > 0)
            {
                var node = currentLevelNodes.Dequeue();
                if (node.val > currentLevelMax)
                    currentLevelMax = node.val;

                if (node.left != null)
                    nextLevelNodes.Enqueue(node.left);
                if (node.right != null)
                    nextLevelNodes.Enqueue(node.right);
            }

            largestValues.Add(currentLevelMax);

            if (nextLevelNodes.Count > 0)
                BFS(largestValues, nextLevelNodes);
        }
    }
}
