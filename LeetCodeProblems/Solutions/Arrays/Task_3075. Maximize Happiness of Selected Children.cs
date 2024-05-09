namespace Solutions.Arrays
{
    internal class Task_3075
    {
        // #Array #Greedy #Sorting

        public long MaximumHappinessSum(int[] happiness, int k)
        {
            long happinessSum = 0;
            Array.Sort(happiness, (a, b) => b.CompareTo(a));
            for (var i = 0; i < k; i++)
            {
                var val = happiness[i] - i;
                if (val <= 0)
                    break;
                happinessSum += val;
            }

            return happinessSum;
        }
    }
}
