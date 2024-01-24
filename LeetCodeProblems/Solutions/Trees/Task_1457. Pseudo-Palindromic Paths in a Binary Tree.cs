namespace Solutions.Trees
{
    internal class Task_1457
    {
        // #Bit Manipulation #Tree #Depth-First Search #Breadth-First Search #Binary Tree
        
        private int ppPathsCounter = 0;

        public int PseudoPalindromicPaths(TreeNode root)
        {
            DFS(root, new int[10]);
            return ppPathsCounter;
        }

        private void DFS(TreeNode node, int[] freq)
        {
            freq[node.val]++;
            if (node.left == null && node.right == null)
            {
                var oddCounter = 0;
                for (var i = 1; i < freq.Length; i++)
                {
                    if (freq[i] % 2 != 0)
                        oddCounter++;
                }
                if (oddCounter <= 1)
                    ppPathsCounter++;
            }

            if (node.left != null)
                DFS(node.left, freq);

            if (node.right != null)
                DFS(node.right, freq);

            freq[node.val]--;
        }
    }
}
