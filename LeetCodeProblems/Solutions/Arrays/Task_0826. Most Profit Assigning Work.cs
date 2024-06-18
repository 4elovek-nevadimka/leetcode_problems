namespace Solutions.Arrays
{
    internal class Task_0826
    {
        // #Array #Two Pointers #Binary Search #Greedy #Sorting

        public void Run()
        {
            // Console.WriteLine(MaxProfitAssignment([2, 4, 6, 8, 10], [10, 20, 30, 40, 50], [4, 5, 6, 7]));
            // Console.WriteLine(MaxProfitAssignment([85, 47, 57], [24, 66, 99], [40, 25, 25]));
            //Console.WriteLine(MaxProfitAssignment(
            //    [2, 17, 19, 20, 24, 29, 33, 43, 50, 51, 57, 67, 70, 72, 73, 75, 80, 82, 87, 90],
            //    [6,  7, 10, 17, 18, 29, 30, 31, 34, 39, 40, 42, 48, 54, 57, 78, 78, 78, 83, 88],
            //    [93]));
            Console.WriteLine(MaxProfitAssignment(
                [66, 1, 28, 73, 53, 35, 45, 60, 100, 44, 59, 94, 27, 88, 7, 18, 83, 18, 72, 63],
                [66, 20, 84, 81, 56, 40, 37, 82, 53, 45, 43, 96, 67, 27, 12, 54, 98, 19, 47, 77],
                [61, 33, 68, 38, 63, 45, 1, 10, 53, 23, 66, 70, 14, 51, 94, 18, 28, 78, 100, 16]));
        }

        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            return Solution1(difficulty, profit, worker);
        }

        private int Solution1(int[] difficulty, int[] profit, int[] worker)
        {
            int maxDifficulty = 0;
            foreach (int curDiff in difficulty)
                if (curDiff > maxDifficulty)
                    maxDifficulty = curDiff;

            var tmpArr = new int[maxDifficulty + 1];
            var profitsDic = new Dictionary<int, int>();
            for (int i = 0; i < difficulty.Length; i++)
            {
                var curDiff = difficulty[i];
                tmpArr[curDiff]++;
                if (!profitsDic.ContainsKey(curDiff))
                    profitsDic[curDiff] = profit[i];
                else
                    if (profit[i] > profitsDic[curDiff])
                    profitsDic[curDiff] = profit[i];
            }

            var sortedDiffs = new List<int>();
            for (int i = 0; i < tmpArr.Length; i++)
                if (tmpArr[i] > 0)
                    sortedDiffs.Add(i);


            for (var i = 1; i < sortedDiffs.Count; i++)
            {
                if (profitsDic[sortedDiffs[i - 1]] > profitsDic[sortedDiffs[i]])
                    profitsDic[sortedDiffs[i]] = profitsDic[sortedDiffs[i - 1]];
            }

            int profitSum = 0;
            foreach (int w in worker)
                if (w >= sortedDiffs[0])
                    profitSum += profitsDic[BinarySearch(w, sortedDiffs)];

            return profitSum;
        }

        private int BinarySearch(int worker, IList<int> sortedDiffs)
        {
            if (worker >= sortedDiffs[^1])
                return sortedDiffs[^1];

            int left = 0, right = sortedDiffs.Count - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (worker == sortedDiffs[mid])
                    return sortedDiffs[mid];
                else if (right - left == 1)
                    return sortedDiffs[mid];

                if (worker > sortedDiffs[mid])
                    left = mid;
                else
                    right = mid;
            }

            return sortedDiffs[^1];
        }

        private int Solution2(int[] difficulty, int[] profit, int[] worker)
        {
            Array.Sort(worker);
            Array.Sort(difficulty, profit);

            int profitSum = 0;
            int i = 0, j = 0, maxProfit = 0;
            while (j < worker.Length)
            {
                if (i < difficulty.Length && worker[j] >= difficulty[i])
                {
                    if (profit[i] > maxProfit)
                        maxProfit = profit[i];
                    i++;
                }
                else
                {
                    profitSum += maxProfit;
                    j++;
                }
            }
            return profitSum;
        }
    }
}
