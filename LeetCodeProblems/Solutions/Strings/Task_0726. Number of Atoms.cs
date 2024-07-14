using System.Text;

namespace Solutions.Strings
{
    internal class Task_0726
    {
        // #Hash Table #String #Stack #Sorting

        public string CountOfAtoms(string formula)
        {
            var stack = new Stack<Dictionary<string, int>>();
            stack.Push([]);

            int index = 0;
            while (index < formula.Length)
            {
                if (formula[index] == '(')
                {
                    stack.Push([]);
                    index++;
                }
                else if (formula[index] == ')')
                {
                    var top = stack.Pop();
                    index++;
                    int start = index;
                    while (index < formula.Length && char.IsDigit(formula[index])) index++;

                    int multiplier = index > start ? int.Parse(formula[start..index]) : 1;
                    foreach (var key in top.Keys)
                    {
                        if (!stack.Peek().ContainsKey(key)) stack.Peek()[key] = 0;
                        stack.Peek()[key] += top[key] * multiplier;
                    }
                }
                else
                {
                    int start = index;
                    index++;
                    while (index < formula.Length && char.IsLower(formula[index])) index++;

                    string element = formula[start..index];
                    start = index;
                    while (index < formula.Length && char.IsDigit(formula[index])) index++;

                    int count = index > start ? int.Parse(formula[start..index]) : 1;
                    if (!stack.Peek().ContainsKey(element)) stack.Peek()[element] = 0;
                    stack.Peek()[element] += count;
                }
            }

            var finalCounts = stack.Pop();
            var result = new List<string>(finalCounts.Keys);
            result.Sort();
            var sb = new StringBuilder();
            foreach (var key in result)
            {
                sb.Append(key);
                if (finalCounts[key] > 1) sb.Append(finalCounts[key]);
            }
            return sb.ToString();
        }
    }
}
