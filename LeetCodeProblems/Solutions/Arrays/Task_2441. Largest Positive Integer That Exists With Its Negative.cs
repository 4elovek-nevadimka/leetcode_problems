namespace Solutions.Arrays
{
    internal class Task_2441
    {
        // #Array #Hash Table #Two Pointers #Sorting

        public void Run()
        {
            Console.WriteLine(FindMaxK([-1, 10, 6, 7, -7, 1]));
            Console.WriteLine(FindMaxK([-9, -43, 24, -23, -16, -30, -38, -30]));
        }

        public int FindMaxK(int[] nums)
        {
            var maxValue = -1;
            var positiveHash = new HashSet<int>();
            var negativeHash = new HashSet<int>();
            foreach (var num in nums)
            {
                if (num > 0)
                {
                    positiveHash.Add(num);
                    if (negativeHash.Contains(-num))
                        maxValue = Math.Max(maxValue, num);
                }
                else
                {
                    negativeHash.Add(num);
                    if (positiveHash.Contains(-num))
                        maxValue = Math.Max(maxValue, -num);
                }
                    
            }

            return maxValue;
        }
    }
}
