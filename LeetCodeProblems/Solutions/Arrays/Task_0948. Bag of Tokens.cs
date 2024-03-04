namespace Solutions.Arrays
{
    internal class Task_0948
    {
        // #Array #Two Pointers #Greedy #Sorting

        public void Run()
        {
            var tokens = new[] { 2, 3, 4 };
            var power = 3;
            Console.WriteLine(BagOfTokensScore(tokens, power));
        }

        public int BagOfTokensScore(int[] tokens, int power)
        {
            Array.Sort(tokens);
            int left = 0, right = tokens.Length - 1;
            int score = 0;

            while (left <= right)
            {
                if (power < tokens[left])
                {
                    if (score == 0 || left == right)
                        return score;
                    // sell
                    power += tokens[right--];
                    score--;
                }
                else
                {
                    // buy
                    power -= tokens[left++];
                    score++;
                }
            }

            return score;
        }
    }
}
