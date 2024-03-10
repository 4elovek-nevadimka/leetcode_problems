namespace Solutions.Arrays
{
    internal class Task_0349
    {
        // #Array #Hash Table #Two Pointers #Binary Search #Sorting

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            return Solution1(nums1, nums2);
        }

        private int[] Solution1(int[] nums1, int[] nums2)
        {
            var hash = new HashSet<int>();
            Array.Sort(nums2);
            foreach (var num in nums1)
                if (Array.BinarySearch<int>(nums2, num) > -1)
                    hash.Add(num);
            return [.. hash];
        }

        private int[] Solution2(int[] nums1, int[] nums2)
        {
            var maxValue = 0;
            foreach (var num in nums1)
                if (num > maxValue)
                    maxValue = num;
            var freqArr = new int[maxValue + 1];
            foreach (var num in nums1)
                freqArr[num]++;

            var hash = new HashSet<int>();
            foreach (var num in nums2)
                if (num < freqArr.Length)
                    if (freqArr[num] > 0)
                        hash.Add(num);

            return [.. hash];
        }

        private int[] Solution3(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).Select(x => x).ToArray();
        }
    }
}
