using System.Text;

namespace Solutions.Trees
{
    internal class Task_0988
    {
        // #String #Tree #Depth-First Search #Binary Tree

        public void Run()
        {
            
        }

        private readonly List<string> _list = [];

        private readonly char[] _alphabetArray = 
            Enumerable.Range('a', 26).Select(x => (char)x).ToArray();

        public string SmallestFromLeaf(TreeNode root)
        {
            Traverse(root, new StringBuilder());
            
            _list.Sort();
            return _list.First();
        }

        private void Traverse(TreeNode node, StringBuilder sb)
        {
            if (node == null)
                return;

            sb.Append(_alphabetArray[node.val]);

            if (node.left == null && node.right == null)
            {
                _list.Add(new string(sb.ToString().Reverse().ToArray()));
                return;
            }

            Traverse(node.left, new StringBuilder(sb.ToString()));
            Traverse(node.right, new StringBuilder(sb.ToString()));
        }
    }
}
