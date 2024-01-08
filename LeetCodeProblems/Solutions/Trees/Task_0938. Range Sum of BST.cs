namespace Solutions.Trees
{
    internal class Task_0938
    {
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return 0;
            // Console.WriteLine(root.val);
            var leftSum = 
                root.val > low ? RangeSumBST(root.left, low, high) : 0;
            var rightSum = 
                root.val < high ? RangeSumBST(root.right, low, high) : 0;
            return 
                leftSum + rightSum + (root.val >= low && root.val <= high ? root.val : 0);
        }
    }
}
