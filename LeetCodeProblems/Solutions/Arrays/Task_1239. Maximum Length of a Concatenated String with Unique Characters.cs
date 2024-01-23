namespace Solutions.Arrays
{
    internal class Task_1239
    {
        public void Run()
        {
            var arr = new[] { "un", "iq", "ue" };
            Console.WriteLine(MaxLength(arr));
        }
        public int MaxLength(IList<string> arr)
        {
            var maxLength = 0;
            var uniquesWords = new HashSet<string>() { "" };

            foreach (var str in arr)
            {
                // check duplicates in str
                if (str.Distinct().Count() != str.Length) continue;

                var newWords = new HashSet<string>();
                foreach (var word in uniquesWords)
                {
                    if (CanConcat(str, word))
                    {
                        var newWord = word + str;
                        newWords.Add(newWord);
                        maxLength = Math.Max(maxLength, newWord.Length);
                    }
                }

                foreach (var word in newWords)
                    uniquesWords.Add(word);
            }

            return maxLength;
        }

        private bool CanConcat(string one, string two)
        {
            foreach (var c in one)
                if (two.Contains(c))
                    return false;
            foreach (var c in two)
                if (one.Contains(c))
                    return false;
            return true;
        }
    }
}
