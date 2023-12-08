using System.Text;

namespace Solutions.Trees
{
    internal class Task_0606
    {
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

        #region StringBuilder Solution

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

        #endregion

        private string Traverse2(TreeNode node)
        {
            if (node == null) return "";

            var str = $"{node.val}";

            if (node.left != null || node.right != null)
            {
                str += $"({Traverse2(node.left)})";
            }

            if (node.right != null)
            {
                str += $"({Traverse2(node.right)})";
            }

            return str;
        }

        
    }
}
