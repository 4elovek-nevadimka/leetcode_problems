namespace Solutions.Strings
{
    internal class Task_1002
    {
        // #

        public void Run()
        {
            var result = CommonChars(["bella", "label", "roller"]);
            Array.ForEach(result.ToArray(), Console.Write);
        }

        public IList<string> CommonChars(string[] words)
        {
            var shortestWord = words[0];
            foreach (var word in words)
                if (shortestWord.Length > word.Length)
                    shortestWord = word;

            var letters = new Dictionary<char, int>();
            foreach (var c in shortestWord)
                if (letters.TryGetValue(c, out int value))
                    letters[c] = ++value;
                else
                    letters[c] = 1;

            foreach (var word in words)
            {
                foreach (var letter in letters.Keys)
                {
                    var letterInWord = word.AsSpan().Count(letter);
                    if (letterInWord < letters[letter])
                        letters[letter] = letterInWord;
                }
            }

            var result = new List<string>();
            foreach (var letter in letters.Keys)
                for (var i = 0; i < letters[letter]; i++)
                    result.Add(letter.ToString());

            return result;
        }
    }
}
