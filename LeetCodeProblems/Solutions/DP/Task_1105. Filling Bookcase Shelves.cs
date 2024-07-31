namespace Solutions.DP
{
    internal class Task_1105
    {
        // #Array #Dynamic Programming

        public int MinHeightShelves(int[][] books, int shelfWidth)
        {
            int[][] memo = new int[books.Length][];
            for (var i = 0; i < books.Length; i++)
                memo[i] = new int[shelfWidth + 1];

            return dpHelper(books, shelfWidth, memo, 0, shelfWidth, 0);
        }

        private int dpHelper(
            int[][] books, int shelfWidth, int[][] memo, 
            int i, int remainingShelfWidth, int maxHeight)
        {
            int[] currentBook = books[i];
            int maxHeightUpdated = Math.Max(maxHeight, currentBook[1]);
            if (i == books.Length - 1)
            {
                if (remainingShelfWidth >= currentBook[0]) return maxHeightUpdated;
                return maxHeight + currentBook[1];
            }
            
            if (memo[i][remainingShelfWidth] != 0)
            {
                return memo[i][remainingShelfWidth];
            }
            else
            {
                
                int option1Height = maxHeight + dpHelper(
                    books, shelfWidth, memo, i + 1, shelfWidth - currentBook[0], currentBook[1]);
                if (remainingShelfWidth >= currentBook[0])
                {
                    int option2Height = dpHelper(
                        books, shelfWidth, memo, i + 1, remainingShelfWidth - currentBook[0], maxHeightUpdated);
                    
                    memo[i][remainingShelfWidth] = Math.Min(option1Height, option2Height);
                    return memo[i][remainingShelfWidth];
                }
                
                memo[i][remainingShelfWidth] = option1Height;
                return memo[i][remainingShelfWidth];
            }
        }
    }
}
