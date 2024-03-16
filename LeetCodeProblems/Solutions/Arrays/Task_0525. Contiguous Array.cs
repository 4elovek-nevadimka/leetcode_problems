namespace Solutions.Arrays
{
    internal class Task_0525
    {
        // #Array #Hash Table #Prefix Sum

        public void Run()
        {
            Console.WriteLine(FindMaxLength([1,1,0,0,1,1,0,1,1]));
        }

        public int FindMaxLength(int[] nums)
        {
            var maxLength = 0;
            var n = nums.Length;
            var sumArr = new int[n];
            sumArr[0] = nums[0] == 0 ? -1 : 1;
            var dic = new Dictionary<int, int> { { sumArr[0], 0 } };
            for (var i = 1; i < n; i++)
            {
                sumArr[i] = sumArr[i - 1] + (nums[i] == 0 ? -1 : 1);
                if (sumArr[i] == 0)
                    maxLength = Math.Max(maxLength, i + 1);
                else
                    if (dic.TryGetValue(sumArr[i], out int value))
                        maxLength = Math.Max(maxLength, i - value);
                    else
                        dic[sumArr[i]] = i;
            }
            return maxLength;
        }
    }
}
