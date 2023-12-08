using System.Text;

namespace Solutions
{
    internal class Task_0606
    {
        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Run()
        {
            // case 1
            var root = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3));
            Console.WriteLine(Tree2str(root));
            Console.WriteLine("1(2(4))(3)");

            _sb.Clear();

            // case 2
            root = new TreeNode(1, new TreeNode(2, null, new TreeNode(4)), new TreeNode(3));
            Console.WriteLine(Tree2str(root));
            Console.WriteLine("1(2()(4))(3)");
        }

        private readonly StringBuilder _sb = new();

        public string Tree2str(TreeNode root)
        {
            Traverse(root);
            return _sb.ToString();
        }

        private void Traverse(TreeNode node)
        {
            if (node == null) return;

            _sb.Append($"{node.val}");

            if (node.left != null || node.right != null)
            {
                _sb.Append('(');
                Traverse(node.left);
                _sb.Append(')');
            }

            if (node.right != null)
            {
                _sb.Append('(');
                Traverse(node.right);
                _sb.Append(')');
            }
        }
    }
}
