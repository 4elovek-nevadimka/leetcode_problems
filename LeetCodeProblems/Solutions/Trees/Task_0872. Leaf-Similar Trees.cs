using System.Text;

namespace Solutions.Trees
{
    internal class Task_0872
    {
        // #Tree #Depth-First Search #Binary Tree

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var leavesOne = new StringBuilder();
            Traverse(root1, leavesOne);

            var leavesTwo = new StringBuilder();
            Traverse(root2, leavesTwo);

            // Console.WriteLine(leavesOne.ToString() + " --> " + leavesTwo.ToString());
            return leavesOne.Equals(leavesTwo);
        }

        private void Traverse(TreeNode node, StringBuilder leaves)
        {
            if (node == null)
                return;

            Traverse(node.left, leaves);

            if (node.left == null && node.right == null)
                leaves.Append(node.val).Append('.');

            Traverse(node.right, leaves);
        }
    }
}
