namespace Solutions.Strings
{
    internal class Task_0076
    {
        // #Hash Table #String #Sliding Window

        public void Run()
        {
            string s = "ADOBECODEBANC", t = "ABC";
            // string s = "ab", t = "b";
            Console.WriteLine(MinWindow(s, t));
        }

        public string MinWindow(string s, string t)
        {
            if (s.Length < t.Length)
                return "";

            var dicT = new Dictionary<char, int>();
            foreach (var c in t)
                if (!dicT.ContainsKey(c))
                    dicT[c] = 1;
                else
                    dicT[c]++;

            int left = 0, right = 0;
            var uniqueCharsOfT = dicT.Keys.Count;
            var dicS = new Dictionary<char, int>();
            int minWindowLeft = 0, minWindowRight = int.MaxValue;

            while (right < s.Length)
            {
                // move right border
                while (right < s.Length)
                {
                    var c = s[right];
                    if (dicT.ContainsKey(c))
                    {
                        if (!dicS.ContainsKey(c))
                            dicS[c] = 1;
                        else
                            dicS[c]++;

                        if (dicS[c] == dicT[c])
                        {
                            uniqueCharsOfT--;
                            if (uniqueCharsOfT == 0)
                                break;
                        }
                    }
                    right++;
                }

                if (uniqueCharsOfT == 0)
                {
                    // move left border
                    while (left < right)
                    {
                        var c = s[left];
                        if (dicT.ContainsKey(c))
                        {
                            dicS[c]--;
                            if (dicS[c] < dicT[c])
                            {
                                uniqueCharsOfT++;
                                break;
                            }
                        }
                        left++;
                    }
                    if (right - left < minWindowRight - minWindowLeft)
                        (minWindowLeft, minWindowRight) = (left, right);
                    left++; right++;
                }
            }

            return minWindowRight == int.MaxValue ? string.Empty
                : s.Substring(minWindowLeft, minWindowRight - minWindowLeft + 1);
        }
    }
}
