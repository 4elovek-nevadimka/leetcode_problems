namespace Solutions
{
    internal class Task_1160
    {
        public void Run()
        {
            // var words = new [] { "hello", "world", "leetcode" };
            var words = new [] { "cat", "bt", "hat", "tree" };

            // var chars = "welldonehoneyr";
            var chars = "atach";

            Console.WriteLine(CountCharacters(words, chars));
        }

        public int CountCharacters(string[] words, string chars)
        {
            return Solution2(words, chars);
        }

        private int Solution1(string[] words, string chars)
        {
            var charsHash = new Dictionary<char, int>();
            foreach (var c in chars)
            {
                if (!charsHash.ContainsKey(c))
                    charsHash[c] = 1;
                else
                    charsHash[c]++;
            }

            var charactersCounter = 0;
            foreach (var word in words)
            {
                // check
                var lastIndex = -2;
                for (var i = 0; i < word.Length; i++)
                {
                    if (!charsHash.ContainsKey(word[i]))
                    {
                        lastIndex = i - 1;
                        break;
                    }
                    if (charsHash[word[i]] == 0)
                    {
                        lastIndex = i - 1;
                        break;
                    }
                    charsHash[word[i]]--;
                }

                if (lastIndex == -2)
                {
                    lastIndex = word.Length - 1;
                    charactersCounter += word.Length;
                }

                // restore hash
                for (var i = lastIndex; i >= 0; i--)
                {
                    charsHash[word[i]]++;
                }
            }

            return charactersCounter;
        }

        private int Solution2(string[] words, string chars)
        {
            var charsHash = new Dictionary<char, int>();
            foreach (var c in chars)
            {
                if (!charsHash.ContainsKey(c))
                    charsHash[c] = 1;
                else
                    charsHash[c]++;
            }

            var charactersCounter = 0;
            foreach (var word in words)
            {
                charactersCounter += ProccessWord(word, charsHash);
            }

            return charactersCounter;
        }

        private int ProccessWord(string word, Dictionary<char, int> charsHash)
        {
            var wordHash = new Dictionary<char, int>();
            for (var i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!charsHash.ContainsKey(c))
                    return 0;

                // fill word hash
                if (!wordHash.ContainsKey(c))
                    wordHash[c] = 1;
                else
                    wordHash[c]++;

                if (charsHash[c] - wordHash[c] < 0)
                    return 0;
            }
            return word.Length;
        }
    }
}
