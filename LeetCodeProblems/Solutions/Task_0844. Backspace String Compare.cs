using System.Text;

namespace Solutions
{
    public class Task_0844
    {
        public bool BackspaceCompare(string s, string t)
        {
            return Solution1(s, t);
        }

        private bool Solution1(string s, string t)
        {
            return GetFormattedString(s) == GetFormattedString(t);
        }

        private string GetFormattedString(string str)
        {
            var index = str.Length - 1;
            var skipChars = 0;
            var strBuilder = new StringBuilder();
            while (index >= 0)
            {
                if (str[index] == '#')
                {
                    skipChars++;
                }
                else
                {
                    if (skipChars > 0)
                    {
                        skipChars--;
                    }
                    else
                    {
                        strBuilder.Append(str[index]);
                    }
                }
                index--;
            }
            return strBuilder.ToString();
        }

        public void Run()
        {
            var s = "ab#c";
            var t = "ad#c";

            var result = BackspaceCompare(s, t);
            Console.WriteLine(result);
        }
    }
}
