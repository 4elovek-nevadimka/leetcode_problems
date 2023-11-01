namespace Solutions
{
    internal class Task_0501
    {
        private int previousValue;
        private int localMaxValue = 1;
        private int currentValueCounter = 1;

        private readonly List<int> results = new();

        public int[] FindMode(TreeNode root)
        {

            previousValue = root.val;
            InorderTraversal(root);
            if (currentValueCounter == localMaxValue)
            {
                if (!results.Contains(previousValue))
                {
                    results.Add(previousValue);
                }
            }
            return results.ToArray();
        }

        private void InorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            // recursion on left child
            InorderTraversal(node.left);

            if (results.Count == 0)
            {
                results.Add(node.val);
            }
            else
            {
                if (node.val == previousValue)
                {
                    currentValueCounter++;
                    if (currentValueCounter > localMaxValue)
                    {
                        results.Clear();
                        results.Add(previousValue);
                        localMaxValue = currentValueCounter;
                    }
                }
                else
                {
                    if (currentValueCounter == localMaxValue)
                    {
                        if (!results.Contains(previousValue))
                        {
                            results.Add(previousValue);
                        }
                    }
                    currentValueCounter = 1;
                }
            }
            previousValue = node.val;

            // recursion on right child
            InorderTraversal(node.right);
        }
    }
}
