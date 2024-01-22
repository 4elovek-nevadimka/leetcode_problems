namespace Solutions.Arrays
{
    internal class Task_0645
    {
        // #Array #Hash Table #Bit Manipulation #Sorting

        public void Run()
        {
            var nums = new[] { 5, 9, 8, 3, 2, 6, 7, 1, 2, 4 };
            Console.WriteLine(FindErrorNums(nums));
        }

        public int[] FindErrorNums(int[] nums)
        {
            return Solution1(nums);
        }

        private int[] Solution1(int[] nums)
        {
            var repeated = 0;
            var n = nums.Length;
            var curSum = nums.Sum();

            var c = 0;
            while (c < n)
            {
                // Console.WriteLine(string.Join(',', nums));
                if (nums[c] != c + 1)
                {
                    if (nums[c] == nums[nums[c] - 1])
                    {
                        repeated = nums[c];
                        break;
                    }
                    (nums[nums[c] - 1], nums[c]) = (nums[c], nums[nums[c] - 1]);
                    continue;
                }
                c++;
            }
            
            var missed = n * (n + 1) / 2 - (curSum - repeated);
            return new int[] { repeated, missed };
        }

        private int[] Solution2(int[] nums)
        {
            int n = nums.Length;
            int missed = 0, repeated = 0;
            var hash = new HashSet<int>(n);
            foreach (var num in nums)
            {
                if (!hash.Add(num))
                    repeated = num;
            }
            for (var i = 1; i <= n; i++)
            {
                if (!hash.Contains(i))
                {
                    missed = i;
                    break;
                }
            }

            return new[] { repeated, missed };
        }
    }
}
