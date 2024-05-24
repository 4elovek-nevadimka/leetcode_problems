namespace Solutions.Arrays
{
    internal class Task_1255
    {
        // #Array #String #Dynamic Programming #Backtracking #Bit Manipulation #Bitmask

        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            var letterCount = new int[26];
            foreach (char letter in letters)
                letterCount[letter - 'a']++;

            return MaxScoreWordsHelper(words, letterCount, score, 0);
        }

        private int MaxScoreWordsHelper(string[] words, int[] letterCount, int[] score, int index)
        {
            if (index == words.Length)
                return 0;

            int skip = MaxScoreWordsHelper(words, letterCount, score, index + 1);

            int include = 0;
            bool canInclude = true;
            int[] wordLetterCount = new int[26];
            foreach (char letter in words[index])
            {
                wordLetterCount[letter - 'a']++;
                if (wordLetterCount[letter - 'a'] > letterCount[letter - 'a'])
                {
                    canInclude = false;
                }
            }

            if (canInclude)
            {
                foreach (char letter in words[index])
                {
                    letterCount[letter - 'a']--;
                    include += score[letter - 'a'];
                }
                include += MaxScoreWordsHelper(words, letterCount, score, index + 1);
                
                foreach (char letter in words[index])
                {
                    letterCount[letter - 'a']++;
                }
            }

            return Math.Max(skip, include);
        }
    }
}
