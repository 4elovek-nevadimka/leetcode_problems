namespace Solutions.Strings
{
    internal class Task_1208
    {
        // #String #Binary Search #Sliding Window #Prefix Sum

        public void Run()
        {
            Console.WriteLine(EqualSubstring("abcd", "cdef", 1));
        }

        public int EqualSubstring(string s, string t, int maxCost)
        {
            int left = 0, right = 0;
            int maxLength = 0, sumCost = 0;

            while (right < s.Length)
            {
                sumCost += Math.Abs(s[right] - t[right]);
                while (sumCost > maxCost)
                {
                    sumCost -= Math.Abs(s[left] - t[left]);
                    left++;
                }
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }
            return maxLength;
        }
    }
}
