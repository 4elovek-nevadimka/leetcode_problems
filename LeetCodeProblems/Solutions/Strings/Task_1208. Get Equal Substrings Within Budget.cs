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
                var curCost = Math.Abs(s[right] - t[right]);
                if (curCost + sumCost <= maxCost)
                {
                    right++;
                    sumCost += curCost;
                    maxLength = Math.Max(maxLength, right - left);
                }
                else
                {
                    if (sumCost > 0)
                        sumCost -= Math.Abs(s[left] - t[left]);
                    left++;
                    if (left > right)
                        right++;
                }
            }
            return maxLength;
        }
    }
}
