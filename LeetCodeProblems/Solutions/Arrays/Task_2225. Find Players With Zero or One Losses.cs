namespace Solutions.Arrays
{
    internal class Task_2225
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            return Solution2(matches);
        }

        private IList<IList<int>> Solution1(int[][] matches)
        {
            var losers = new Dictionary<int, int>();
            foreach (var match in matches)
            {
                if (!losers.ContainsKey(match[1]))
                    losers.Add(match[1], 1);
                else
                    losers[match[1]]++;
            }

            var winners = new List<int>();
            foreach (var match in matches)
            {
                if (!losers.ContainsKey(match[0]))
                    if (!winners.Contains(match[0]))
                        winners.Add(match[0]);
            }

            return new List<IList<int>>
            {
                new List<int>(
                    winners.OrderBy(x => x)),
                new List<int>(
                    losers.Where(x => x.Value == 1).Select(x => x.Key).OrderBy(x => x))
            };
        }

        private IList<IList<int>> Solution2(int[][] matches)
        {
            var losersFreqArr = GetFreqArr(matches, 1);
            var winnersFreqArr = GetFreqArr(matches, 0);

            var winnersList = new List<int>();
            for (var i = 0; i < winnersFreqArr.Length; i++)
            {
                if (winnersFreqArr[i] > 0)
                {
                    if (i < losersFreqArr.Length)
                    {
                        if (losersFreqArr[i] == 0)
                        {
                            winnersList.Add(i);
                        }
                    }
                    else
                    {
                        winnersList.Add(i);
                    }
                }
            }

            var losersList = new List<int>();
            for (var i = 0; i < losersFreqArr.Length; i++)
            {
                if (losersFreqArr[i] == 1)
                    losersList.Add(i);
            }

            return new List<IList<int>> { winnersList, losersList };
        }

        private int[] GetFreqArr(int[][] matches, int pairItem)
        {
            var maxValue = 0;
            foreach (var match in matches)
            {
                maxValue = Math.Max(match[pairItem], maxValue);
            }
            var freqArr = new int[maxValue + 1];
            foreach (var match in matches)
            {
                freqArr[match[pairItem]]++;
            }
            return freqArr;
        }
    }
}
