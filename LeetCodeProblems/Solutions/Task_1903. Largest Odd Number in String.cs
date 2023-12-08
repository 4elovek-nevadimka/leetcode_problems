namespace Solutions
{
    internal class Task_1903
    {
        public string LargestOddNumber(string num)
        {
            return Solution2(num);
        }

        private string Solution1(string num)
        {
            var odds = new HashSet<char>(new[] { '1', '3', '5', '7', '9' });
            for (var i = num.Length - 1; i >= 0; i--)
            {
                if (odds.Contains(num[i]))
                {
                    return num.Substring(0, i + 1);
                }
            }
            return "";
        }

        private string Solution2(string num)
        {
            for (var i = num.Length - 1; i >= 0; i--)
            {
                var c = num[i];
                if (c == '1' || c == '3' || c == '5' || c == '7' || c == '9')
                {
                    return num.Substring(0, i + 1);
                }
            }
            return "";
        }
    }
}
