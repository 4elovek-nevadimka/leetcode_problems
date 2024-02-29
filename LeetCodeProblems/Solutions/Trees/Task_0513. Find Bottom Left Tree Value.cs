namespace Solutions.Trees
{
    internal class Task_0513
    {
        // #Tree #Depth-First Search #Breadth-First Search #Binary Tree

        private int m_MaxLevel = -1;

        private int m_BottomLeft = -1;

        public int FindBottomLeftValue(TreeNode root)
        {
            TraverseTree(root, 0);
            return m_BottomLeft;
        }

        private void TraverseTree(TreeNode node, int level)
        {
            if (node == null)
                return;

            if (level > m_MaxLevel)
            {
                m_BottomLeft = node.val;
                m_MaxLevel = level;
            }

            TraverseTree(node.left, level + 1);
            TraverseTree(node.right, level + 1);
        }
    }
}
