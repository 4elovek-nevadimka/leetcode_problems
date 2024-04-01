namespace Solutions.Strings
{
    internal class Task_0058
    {
        // #String

        public int LengthOfLastWord(string s)
        {
            return Solution1(s);
        }

        private int Solution1(string s)
        {
            return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last().Length;
        }

        private int Solution2(string s)
        {
            int index = s.Length - 1;
            while (s[index] == ' ')
                index--;

            int lastCharIndex = index;
            while (index > 0)
                if (s[--index] == ' ')
                    break;

            if (index == 0 && s[index] != ' ')
                index--;

            return lastCharIndex - index;
        }
    }
}
