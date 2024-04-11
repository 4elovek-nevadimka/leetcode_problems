using System.Text;

namespace Solutions.Strings
{
    internal class Task_0402
    {
        // #String #Stack #Greedy #Monotonic Stack

        public void Run()
        {
            Console.WriteLine(RemoveKdigits("1432219", 3));
            Console.WriteLine(RemoveKdigits("10200", 1));
            Console.WriteLine(RemoveKdigits("10", 2));

            Console.WriteLine(RemoveKdigits("1432211", 4));
        }

        public string RemoveKdigits(string num, int k)
        {
            return Solution1(num, k);
        }

        private string Solution1(string num, int k)
        {
            if (k == num.Length) return "0";

            var removed = 0;
            var stack = new Stack<char>();

            foreach (var digit in num)
            {
                while (stack.Count > 0 && stack.Peek() > digit && removed < k)
                {
                    stack.Pop();
                    removed++;
                }
                stack.Push(digit);
            }

            while (removed < k)
            {
                stack.Pop();
                removed++;
            }

            var sb = new StringBuilder(stack.Count);
            while (stack.Count > 0)
                sb.Insert(0, stack.Pop());

            var result = sb.ToString().TrimStart('0');
            return string.IsNullOrEmpty(result) ? "0" : result;
        }

        private string Solution2(string num, int k)
        {
            // > ??
            return num;
        }
    }
}
