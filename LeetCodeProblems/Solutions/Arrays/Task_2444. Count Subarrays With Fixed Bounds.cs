namespace Solutions.Arrays
{
    internal class Task_2444
    {
        // #Array #Queue #Sliding Window #Monotonic Queue

        public void Run()
        {
            // Console.WriteLine(CountSubarrays([1, 3, 5, 2, 7, 5], 1, 5));
            Console.WriteLine(CountSubarrays([1, 1, 1, 1], 1, 1));
        }

        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            long result = 0;
            int start = 0, min = -1, max = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= minK && nums[i] <= maxK)
                {
                    if (nums[i] == minK)
                        min = i;
                    if (nums[i] == maxK)
                        max = i;
                    result += Math.Max(0, Math.Min(min, max) - start + 1);
                }
                else
                {
                    start = i + 1;
                    min = max = -1;
                }
            }

            return result;
        }
    }
}
