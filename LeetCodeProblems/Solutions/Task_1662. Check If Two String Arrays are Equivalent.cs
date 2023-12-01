using System.Reflection;
using System.Text;

namespace Solutions
{
    internal class Task_1662
    {
        public void Run()
        {
            var word1 = new[] { "abc", "d", "defg" };
            var word2 = new[] { "abcddefg" };

            Console.WriteLine(ArrayStringsAreEqual(word1, word2));
        }
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return Solution1(word1, word2);
        }

        private bool Solution1(string[] word1, string[] word2)
        {
            var sb1 = new StringBuilder();
            foreach (var part in word1)
            {
                sb1.Append(part);
            }
            var sb2 = new StringBuilder();
            foreach (var part in word2)
            {
                sb2.Append(part);
            }

            return sb1.ToString() == sb2.ToString();
        }

        private bool Solution2(string[] word1, string[] word2)
        {
            return string.Join("", word1) == string.Join("", word2);
        }

        private bool Solution3(string[] word1, string[] word2)
        {
            // word pointer
            int word1Pointer = 0, word2Pointer = 0;
            // character pointer in the word
            int string1Pointer = 0, string2Pointer = 0;

            while (word1Pointer < word1.Length && word2Pointer < word2.Length)
            {
                if (word1[word1Pointer][string1Pointer++] !=
                    word2[word2Pointer][string2Pointer++])
                {
                    return false;
                }
                
                if (string1Pointer == word1[word1Pointer].Length)
                {
                    word1Pointer++;
                    string1Pointer = 0;
                }
                if (string2Pointer == word2[word2Pointer].Length)
                {
                    word2Pointer++;
                    string2Pointer = 0;
                }
            }
            
            return word1Pointer == word1.Length && word2Pointer == word2.Length;
        }
    }
}
