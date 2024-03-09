namespace Solutions.Arrays
{
    internal class Task_2540
    {
        // #Array #Hash Table #Two Pointers #Binary Search

        public int GetCommon(int[] nums1, int[] nums2)
        {
            return Solution1(nums1, nums2);
        }

        private int Solution1(int[] nums1, int[] nums2)
        {
            int pointerA = 0, pointerB = 0;
            while (pointerA < nums1.Length)
            {
                var num = nums1[pointerA++];
                while (pointerB < nums2.Length && nums2[pointerB] <= num)
                {
                    if (nums2[pointerB++] == num)
                        return num;
                }
            }
            return -1;
        }

        private int Solution2(int[] nums1, int[] nums2)
        {
            foreach (var num in nums1)
            {
                if (Array.BinarySearch<int>(nums2, num) > -1)
                    return num;
            }
            return -1;
        }
    }
}
