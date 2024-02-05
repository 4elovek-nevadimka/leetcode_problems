namespace Solutions.Strings
{
    internal class Task_0387
    {
        // #Hash Table #String #Queue #Counting

        public int FirstUniqChar(string s)
        {
            var alphabet = new int[26];
            Array.Fill(alphabet, -1);

            for (var i = 0; i < s.Length; i++)
            {
                var iChar = s[i] - 'a';
                if (alphabet[iChar] == -1)
                    alphabet[iChar] = i;
                else
                    alphabet[iChar] = -2;
            }

            var minxIndex = s.Length;
            foreach (var val in alphabet)
            {
                if (val >= 0)
                    minxIndex = Math.Min(minxIndex, val);
            }

            return minxIndex == s.Length ? -1 : minxIndex;
        }
    }
}
