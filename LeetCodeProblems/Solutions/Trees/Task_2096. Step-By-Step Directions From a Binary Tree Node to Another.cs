using System.Text;

namespace Solutions.Trees
{
    internal class Task_2096
    {
        // #String #Tree #Depth-First Search #Binary Tree

        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            var lowestCommonAncestor = FindLowestCommonAncestor(root, startValue, destValue);

            var pathToStart = new StringBuilder();
            FindPath(lowestCommonAncestor, startValue, pathToStart);

            var pathToDest = new StringBuilder();
            FindPath(lowestCommonAncestor, destValue, pathToDest);

            var directions = new StringBuilder();
            directions.Append('U', pathToStart.Length);
            directions.Append(pathToDest);

            return directions.ToString();
        }

        private TreeNode FindLowestCommonAncestor(TreeNode node, int value1, int value2)
        {
            if (node == null) return null;

            if (node.val == value1 || node.val == value2) return node;

            var leftLCA = FindLowestCommonAncestor(node.left, value1, value2);
            var rightLCA = FindLowestCommonAncestor(node.right, value1, value2);

            if (leftLCA == null) return rightLCA;
            else if (rightLCA == null) return leftLCA;
            else return node;
        }

        private bool FindPath(TreeNode node, int targetValue, StringBuilder path)
        {
            if (node == null) return false;

            if (node.val == targetValue) return true;

            path.Append("L");
            if (FindPath(node.left, targetValue, path))
                return true;

            path.Remove(path.Length - 1, 1);

            
            path.Append("R");
            if (FindPath(node.right, targetValue, path))
                return true;

            path.Remove(path.Length - 1, 1);

            return false;
        }
    }
}
