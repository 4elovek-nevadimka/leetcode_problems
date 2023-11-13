using System.Text;

namespace Solutions
{
    internal class Task_2785
    {
        public void Run()
        {
            // var s = "lEetcOde";
            var s = "lYmpH";

            Console.WriteLine(SortVowels(s));
        }

        public string SortVowels(string s)
        {
            var vowels = new List<char>(
                new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });

            var vowelsIndices = new List<int>();
            var vowelsCodes = new List<int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    vowelsIndices.Add(i);
                    vowelsCodes.Add(s[i]);
                }
            }

            if (vowelsCodes.Count == 0) return s;

            vowelsCodes.Sort();

            var newS = new StringBuilder(s);
            for (var i = 0; i < vowelsIndices.Count; i++)
            {
                newS[vowelsIndices[i]] = (char)vowelsCodes[i];
            }
            return newS.ToString();
        }
    }
}
