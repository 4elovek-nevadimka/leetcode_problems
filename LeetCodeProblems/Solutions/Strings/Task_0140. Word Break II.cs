using System.Text;

namespace Solutions.Strings
{
    internal class Task_0140
    {
        // #Array #Hash Table #String #Dynamic Programming #Backtracking #Trie #Memoization

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var result = new List<string>();

            WordBreakHelper(s, wordDict, new StringBuilder(), result);

            return result;
        }

        private void WordBreakHelper(string s, IList<string> wordDict, StringBuilder resultPart, IList<string> result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result.Add(resultPart.ToString().TrimEnd());
                return;
            }

            foreach (var word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    resultPart.Append(word);
                    resultPart.Append(' ');
                    WordBreakHelper(s.Remove(0, word.Length), wordDict, resultPart, result);

                    var partToremove = word.Length + 1;
                    resultPart.Remove(resultPart.Length - partToremove, partToremove);
                }
            }
        }
    }
}
