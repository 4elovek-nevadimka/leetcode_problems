using System.Xml.Linq;

namespace Solutions.Trees
{
    internal class Task_1382
    {
        // #Divide and Conquer #Greedy #Tree #Depth-First Search #Binary Search Tree #Binary Tree

        public void Run()
        {
            //BalanceBST(TreeNodeGenerator.Generate(
            //    [1, null, 2, null, 3, null, 4, null, null]));
            // BalanceBST(TreeNodeGenerator.Generate([2, 1, 3]));
        }

        public TreeNode BalanceBST(TreeNode root)
        {
            var listOfNodeValues = new List<int>();
            TraverseInOrder(root, listOfNodeValues);

            return CreateBalancedBTree(listOfNodeValues, 0, listOfNodeValues.Count - 1);
        }

        private void TraverseInOrder(TreeNode node, List<int> values)
        {
            if (node == null) return;

            TraverseInOrder(node.left, values);

            values.Add(node.val);

            TraverseInOrder(node.right, values);
        }

        private TreeNode CreateBalancedBTree(List<int> nodes, int left, int right)
        {
            if (left > right) return null;

            int mid = left + (right - left) / 2;
            var node = new TreeNode(nodes[mid]);
            node.left = CreateBalancedBTree(nodes, left, mid - 1);
            node.right = CreateBalancedBTree(nodes, mid + 1, right);
            return node;
        }
    }
}
