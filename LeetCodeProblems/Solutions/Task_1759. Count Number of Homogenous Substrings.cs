namespace Solutions
{
    internal class Task_1759
    {
        public int CountHomogenous(string s)
        {
            const int MOD = 1000000007;

            int charCounter = 1, homogenousCount = 0;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    charCounter++;
                }
                else
                {
                    homogenousCount +=
                        (int)((long)charCounter * (charCounter + 1) / 2 % MOD);
                    charCounter = 1;
                }
            }
            homogenousCount +=
                (int)((long)charCounter * (charCounter + 1) / 2 % MOD);
            return homogenousCount;
        }

        public int CountHomogenous2(string s)
        {
            // modulo 10^9 + 7
            const int MOD = 1000000007;

            int charCounter = 0, homogenousCount = 0;

            char previousChar = s[0];
            foreach (var c in s)
            {
                if (c == previousChar)
                {
                    charCounter++;
                }
                else
                {
                    // arithmetic progression
                    homogenousCount += (int)((long)charCounter * (charCounter + 1) / 2 % MOD);
                    previousChar = c;
                    charCounter = 1;
                }
            }
            homogenousCount += (int)((long)charCounter * (charCounter + 1) / 2 % MOD);
            return homogenousCount;
        }
    }
}
