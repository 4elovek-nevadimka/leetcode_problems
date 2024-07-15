namespace Solutions.Trees
{
    internal class Task_2196
    {
        // #Array #Hash Table #Tree #Binary Tree

        public void Run()
        {
            Console.WriteLine(CreateBinaryTree(
                [[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]]));
        }

        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            var childSet = new HashSet<int>();
            var nodesDic = new Dictionary<int, TreeNode>();
            foreach (var node in descriptions)
            {
                if (!nodesDic.TryGetValue(node[0], out TreeNode parent))
                {
                    parent = new TreeNode(node[0]);
                    nodesDic[node[0]] = parent;
                }

                if (!nodesDic.TryGetValue(node[1], out TreeNode child))
                {
                    child = new TreeNode(node[1]);
                    nodesDic[node[1]] = child;
                }
                childSet.Add(node[1]);


                if (node[2] == 1)
                    parent.left = child;
                else
                    parent.right = child;
            }

            foreach (var nodeValue in nodesDic.Keys)
                if (!childSet.Contains(nodeValue))
                    return nodesDic[nodeValue];

            return null;
        }
    }
}
