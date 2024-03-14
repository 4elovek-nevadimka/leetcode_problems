namespace Solutions.Arrays
{
    internal class Task_0930
    {
        // #Array #Hash Table #Sliding Window #Prefix Sum

        public void Run()
        {
            Console.WriteLine(NumSubarraysWithSum([1, 0, 1, 0, 1], 2));
            // Console.WriteLine(NumSubarraysWithSum([1, 0, 1, 0, 1], 2));
        }

        public int NumSubarraysWithSum(int[] nums, int goal)
        {
            int sum = 0, count = 0;
            var dic = new Dictionary<int, int> { [0] = 1 };

            foreach (var num in nums)
            {
                sum += num;
                if (dic.ContainsKey(sum - goal))
                    count += dic[sum - goal];
                if (!dic.ContainsKey(sum))
                    dic[sum] = 0;
                dic[sum]++;
            }

            return count;
        }
    }
}
