namespace Solutions.Strings
{
    internal class Task_2000
    {
        // #Two Pointers #String

        public void Run()
        {
            Console.WriteLine(ReversePrefix("xyxzxe", 'z'));
        }

        public string ReversePrefix(string word, char ch)
        {
            if (!word.Contains(ch))
                return word;

            var index = word.IndexOf(ch);
            var charArr = index == word.Length - 1 
                ? word.ToCharArray() : word[..(index + 1)].ToCharArray();
            Array.Reverse(charArr);

            return index == word.Length - 1 ? 
                new string(charArr) : string.Concat(new string(charArr), word.AsSpan(index + 1));
        }
    }
}
