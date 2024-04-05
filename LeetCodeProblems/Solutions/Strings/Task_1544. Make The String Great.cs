using System.Text;

namespace Solutions.Strings
{
    internal class Task_1544
    {
        // #String #Stack

        public void Run()
        {
            Console.WriteLine(MakeGood("leEeetcode"));
            Console.WriteLine(MakeGood("abBAcC"));
            Console.WriteLine(MakeGood("s"));
        }

        public string MakeGood(string s)
        {
            return Solution3(s);
        }

        private string Solution1(string s)
        {
            var n = s.Length;
            var goodString = new StringBuilder();
            for (var i = 0; i < n; i++)
                if ((i < n - 1) && (Math.Abs(s[i] - s[i + 1]) == 32))
                    i++;
                else
                    goodString.Append(s[i]);

            if (goodString.Length != n)
                return MakeGood(goodString.ToString());

            return goodString.ToString();
        }

        private string Solution2(string s)
        {
            var n = s.Length;
            var goodString = new StringBuilder();
            for (var i = 0; i < n; i++)
                if ((i < n - 1) && (Math.Abs(s[i] - s[i + 1]) == 32))
                    i++;
                else
                    if ((goodString.Length > 0) && (Math.Abs(s[i] - goodString[^1]) == 32))
                        goodString.Remove(goodString.Length - 1, 1);
                    else
                        goodString.Append(s[i]);

            return goodString.ToString();
        }

        private string Solution3(string s)
        {
            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
                if ((i < s.Length - 1) && (Math.Abs(s[i] - s[i + 1]) == 32))
                    i++;
                else
                    if (stack.TryPeek(out char last) && Math.Abs(s[i] - last) == 32)
                        stack.Pop();
                    else
                        stack.Push(s[i]);

            var goodString = new StringBuilder();
            while (stack.Count > 0)
                goodString.Insert(0, stack.Pop());

            return goodString.ToString();
        }
    }
}
