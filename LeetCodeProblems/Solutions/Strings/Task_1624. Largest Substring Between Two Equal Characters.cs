namespace Solutions.Strings
{
    internal class Task_1624
    {
        // #Hash Table #String

        public int MaxLengthBetweenEqualCharacters(string s)
        {
            var firstPositions = new Dictionary<char, int>();
            var maxLengthBetween = -1;
            for (var i = 0; i < s.Length; i++)
            {
                if (!firstPositions.ContainsKey(s[i]))
                {
                    firstPositions.Add(s[i], i);
                }
                else
                {
                    maxLengthBetween = 
                        Math.Max(maxLengthBetween, i - firstPositions[s[i]] - 1);
                }
            }
            return maxLengthBetween;
        }
    }
}
