namespace Solutions.Trees
{
    internal static class TreeNodeGenerator
    {
        internal static TreeNode Generate(int?[] arr)
        {
            if (arr == null || arr.Length == 0 || !arr[0].HasValue)
                return null;

            var root = new TreeNode(arr[0].Value);
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            int i = 1;
            while (i < arr.Length)
            {
                var current = queue.Dequeue();

                if (i < arr.Length && arr[i].HasValue)
                {
                    current.left = new TreeNode(arr[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < arr.Length && arr[i].HasValue)
                {
                    current.right = new TreeNode(arr[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }
            return root;
        }
    }
}
