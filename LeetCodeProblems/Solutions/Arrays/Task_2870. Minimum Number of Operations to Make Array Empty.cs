namespace Solutions.Arrays
{
    internal class Task_2870
    {
        // #Array #Hash Table #Greedy #Counting

        public int MinOperations(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]++;
            }

            var minOperationsCount = 0;
            foreach (var num in dic.Keys)
            {
                if (dic[num] == 1)
                    return -1;
                if (dic[num] == 2)
                {
                    minOperationsCount++; // 1 operation
                    continue;
                }
                if (dic[num] == 4)
                {
                    minOperationsCount += 2; // 2 operations
                    continue;
                }
                // other cases
                var reminder = dic[num] % 3;
                if (reminder == 0)
                {
                    minOperationsCount += dic[num] / 3;
                }
                else if (reminder == 1)
                {
                    minOperationsCount += 2; // 2 operations
                    minOperationsCount += (dic[num] - 4) / 3;
                }
                else
                {
                    minOperationsCount++; // 1 operation
                    minOperationsCount += (dic[num] - 2) / 3;
                }
            }

            return minOperationsCount;
        }

        private int Solution2(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]++;
            }

            var minOperationsCount = 0;
            foreach (var num in dic.Keys)
            {
                if (dic[num] == 1)
                    return -1;
                minOperationsCount += (int)Math.Ceiling(dic[num] / 3.0);
            }

            return minOperationsCount;
        }
    }
}
