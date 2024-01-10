namespace Solutions.Trees
{
    internal class Task_2385
    {
        private readonly Dictionary<int, List<int>> _graph = new();

        public int AmountOfTime(TreeNode root, int start)
        {
            Traverse(root, null);
            //foreach (var key in _graph.Keys)
            //{
            //    Console.WriteLine($"{key}: {String.Join(',', _graph[key])}");
            //}
            var mins = -1;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            var visited = new HashSet<int> { start };

            while(queue.Count > 0)
            {
                mins++;
                var curQueueCount = queue.Count;
                while (curQueueCount > 0)
                {
                    foreach (var neighbor in _graph[queue.Dequeue()])
                    {
                        if (visited.Add(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                    curQueueCount--;
                }
            }
            return mins;
        }

        private void Traverse(TreeNode node, TreeNode previous)
        {
            if (node == null)
                return;

            var neighbors = new List<int>();

            if (previous != null)
            {
                neighbors.Add(previous.val);
            }
            if (node.left != null)
            {
                neighbors.Add(node.left.val);
                Traverse(node.left, node);
            }
            if (node.right != null)
            {
                neighbors.Add(node.right.val);
                Traverse(node.right, node);
            }
            _graph.Add(node.val, neighbors);
        }
    }
}
