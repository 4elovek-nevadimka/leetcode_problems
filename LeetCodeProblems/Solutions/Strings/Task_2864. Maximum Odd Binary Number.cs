using System.Text;

namespace Solutions.Strings
{
    internal class Task_2864
    {
        // #Math #String #Greedy

        public string MaximumOddBinaryNumber(string s)
        {
            return Solution1(s);
        }

        private string Solution1(string s)
        {
            var counter = -1;
            foreach (var c in s)
                if (c == '1')
                    counter++;

            var sb = new StringBuilder(s.Length);
            sb.Append('1', counter)
                .Append('0', s.Length - 1 - counter).Append('1');
            return sb.ToString();
        }

        private string Solution2(string s)
        {
            var counter = -1;
            foreach (var c in s)
                if (c == '1')
                    counter++;

            var arr = new char[s.Length];
            Array.Fill(arr, '0');
            for (var i = 0; i < counter; i++)
                arr[i] = '1';
            arr[^1] = '1';
            
            return new string(arr);
        }
    }
}
