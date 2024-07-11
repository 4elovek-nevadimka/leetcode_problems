using System.Text;

namespace Solutions.Strings
{
    internal class Task_1190
    {
        // #String #Stack

        public string ReverseParentheses(string s)
        {
            return Solution1(s);
        }

        private string Solution1(string s)
        {
            var result = new StringBuilder();
            var parenthesesIndices = new Stack<int>();

            foreach (var c in s)
            {
                if (c == '(')
                {
                    parenthesesIndices.Push(result.Length);
                }
                else if (c == ')')
                {
                    var from = parenthesesIndices.Pop();
                    Reverse(result, from, result.Length - 1);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private void Reverse(StringBuilder sb, int from, int to)
        {
            while (from < to)
            {
                var tmp = sb[from];
                sb[from++] = sb[to];
                sb[to--] = tmp;
            }
        }

        private string Solution2(string s)
        {
            var pairIndices = new int[s.Length];
            var parenthesesIndices = new Stack<int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    parenthesesIndices.Push(i);
                }
                else if (s[i] == ')')
                {
                    var from = parenthesesIndices.Pop();
                    pairIndices[i] = from;
                    pairIndices[from] = i;
                }
            }

            var result = new StringBuilder();
            int index = 0, direction = 1;
            while (index < s.Length)
            {
                if (s[index] == '(' || s[index] == ')')
                {
                    index = pairIndices[index];
                    direction = -direction;
                }
                else
                    result.Append(s[index]);
                index += direction;
            }

            return result.ToString();
        }
    }
}
