namespace Solutions.Arrays
{
    internal class Task_2149
    {
        public int[] RearrangeArray(int[] nums)
        {
            var result = new int[nums.Length];
            int posCounter = 0, negCounter = 1;

            foreach (var num in nums)
            {
                if (num < 0)
                {
                    result[negCounter] = num;
                    negCounter += 2;
                }
                else
                {
                    result[posCounter] = num;
                    posCounter += 2;
                }
            }

            return result;
        }
    }
}
