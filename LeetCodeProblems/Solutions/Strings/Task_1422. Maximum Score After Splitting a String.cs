namespace Solutions.Strings
{
    internal class Task_1422
    {
        // #String

        public void Run()
        {
            Console.WriteLine(MaxScore("011101"));
        }

        public int MaxScore(string s)
        {
            var curScore = s[0] == '0' ? 1 : 0;
            for (var i = 1; i < s.Length; i++)
                if (s[i] == '1')
                    curScore++;

            var maxScore = curScore;
            for (var i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == '0')
                    curScore++;
                else
                    curScore--;
                maxScore = Math.Max(maxScore, curScore);
            }
            return maxScore;
        }
    }
}
