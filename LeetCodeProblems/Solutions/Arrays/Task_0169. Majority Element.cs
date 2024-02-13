namespace Solutions.Arrays
{
    internal class Task_0169
    {
        // #Array #Hash Table #Divide and Conquer #Sorting #Counting

        public int MajorityElement(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (int x in nums)
            {
                if (!dic.ContainsKey(x))
                    dic[x] = 1;
                else
                    dic[x]++;
            }

            foreach (var x in dic.Keys)
                if (dic[x] > nums.Length / 2)
                    return x;

            return 0;
        }

        // Boyer Moore majority voting algorithm
        private int Solution2(int[] nums)
        {
            int candidate = nums[0], count = 0;

            foreach (var num in nums)
            {
                if (num == candidate)
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    candidate = num;
                    count = 1;
                }
            }
            return candidate;
        }
    }
}
