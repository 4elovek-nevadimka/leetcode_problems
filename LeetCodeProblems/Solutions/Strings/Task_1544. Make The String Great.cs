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
    }
}
