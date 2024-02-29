namespace Solutions.Trees
{
    internal class Task_1609
    {
        public bool IsEvenOddTree(TreeNode root)
        {
            if (root.val % 2 == 0)
                return false;

            var evenLevel = true;
            var previousValue = 0;
            var queue = new Queue<TreeNode>(new[] { root });

            while (queue.Count > 0)
            {
                var n = queue.Count;
                for (var i = 0; i < n; i++)
                {
                    var currentNode = queue.Dequeue();
                    if (evenLevel)
                    {
                        if (currentNode.val % 2 == 0)
                            return false;
                        if (i > 0)
                            if (currentNode.val <= previousValue)
                                return false;
                    }
                    else
                    {
                        if (currentNode.val % 2 == 1)
                            return false;
                        if (i > 0)
                            if (currentNode.val >= previousValue)
                                return false;
                    }
                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                    previousValue = currentNode.val;
                }
                evenLevel = !evenLevel;
            }
            return true;
        }
    }
}
