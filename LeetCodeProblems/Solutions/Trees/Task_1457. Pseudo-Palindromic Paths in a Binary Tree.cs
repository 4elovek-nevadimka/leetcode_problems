namespace Solutions.Trees
{
    internal class Task_1457
    {
        // #Bit Manipulation #Tree #Depth-First Search #Breadth-First Search #Binary Tree

        public int PseudoPalindromicPaths(TreeNode root)
        {
            return DFS(root, new int[10]);
        }

        private int DFS(TreeNode node, int[] freq)
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
                freq[node.val]--;
                return oddCounter <= 1 ? 1 : 0;
            }

            var left = node.left != null ? DFS(node.left, freq) : 0;
            var right = node.right != null ? DFS(node.right, freq) : 0;

            freq[node.val]--;

            return left + right;
        }
    }
}
