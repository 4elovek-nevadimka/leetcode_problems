using System.Collections.Generic;

namespace Solutions.Trees
{
    internal class Task_1530
    {
        // #Tree #Depth-First Search #Binary Tree

        public int CountPairs(TreeNode root, int distance)
        {
            int result = 0;
            DFS(root, distance, ref result);

            return result;
        }

        // Depth-First Search helper function
        private int[] DFS(TreeNode node, int distance, ref int result)
        {
            if (node == null)
            {
                return new int[11];
            }

            // If it's a leaf node
            if (node.left == null && node.right == null)
            {
                var leafCounts = new int[11];
                leafCounts[1] = 1;
                return leafCounts;
            }

            var leftCounts = DFS(node.left, distance, ref result);
            var rightCounts = DFS(node.right, distance, ref result);

            // Count good leaf node pairs
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (i + j <= distance)
                    {
                        result += leftCounts[i] * rightCounts[j];
                    }
                }
            }

            // Combine counts
            var counts = new int[11];
            for (int i = 1; i < 10; i++)
            {
                counts[i + 1] = leftCounts[i] + rightCounts[i];
            }

            return counts;
        }
    }
}
