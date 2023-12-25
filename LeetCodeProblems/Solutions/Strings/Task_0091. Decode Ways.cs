namespace Solutions.Strings
{
    internal class Task_0091
    {
        // #String #Dynamic Programming

        public void Run()
        {
            Console.WriteLine(NumDecodings("20419"));
        }

        public int NumDecodings(string s)
        {
            char prevChar = s[0];
            int counter1, counter2;
            int prevCounter1 = prevChar != '0' ? 1 : 0, prevCounter2 = 0;

            for (var i = 1; i < s.Length; i++)
            {
                // counter1
                if (s[i] != '0')
                    counter1 = prevCounter1 + prevCounter2;
                else
                    counter1 = 0;

                // counter2
                if ((prevChar == '1') || (
                    (prevChar == '2') && s[i] != '9' && s[i] != '8' && s[i] != '7'))
                {
                    counter2 = prevCounter1;
                }
                else
                    counter2 = 0;
                // update previous
                (prevCounter1, prevCounter2) = (counter1, counter2);
                prevChar = s[i];
            }

            return prevCounter1 + prevCounter2;
        }
    }
}
