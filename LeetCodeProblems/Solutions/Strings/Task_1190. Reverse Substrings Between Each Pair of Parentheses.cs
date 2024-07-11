using System.Text;

namespace Solutions.Strings
{
    internal class Task_1190
    {
        // #String #Stack

        public string ReverseParentheses(string s)
        {
            var parenthesesIndices = new Stack<int>();
            var result = new StringBuilder();

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
    }
}
