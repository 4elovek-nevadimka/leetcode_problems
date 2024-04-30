namespace Solutions.BitManipulation
{
    // #Hash Table #String #Bit Manipulation #Prefix Sum

    internal class Task_1915
    {
        public long WonderfulSubstrings(string word)
        {
            var dic = new Dictionary<int, long>();
            dic[0] = 1;
            long result = 0;
            int mask = 0;

            foreach (char c in word)
            {
                mask ^= 1 << (c - 'a');
                result += dic.GetValueOrDefault(mask, 0);

                for (int i = 0; i < 10; i++)
                {
                    int checkMask = mask ^ (1 << i);
                    result += dic.GetValueOrDefault(checkMask, 0);
                }

                dic[mask] = dic.GetValueOrDefault(mask, 0) + 1;
            }

            return result;
        }
    }
}
