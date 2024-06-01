namespace Solutions.Strings
{
    internal class Task_3110
    {
        // #String

        public int ScoreOfString(string s)
        {
            var score = 0;
            for (var i = 1; i < s.Length; i++)
                score += Math.Abs(s[i - 1] - s[i]);

            return score;
        }
    }
}
