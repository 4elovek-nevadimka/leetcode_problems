namespace Solutions.Arrays
{
    internal class Task_1052
    {
        // #Array #Sliding Window

        public void Run()
        {
            Console.WriteLine(MaxSatisfied([1, 0, 1, 2, 1, 1, 7, 5], [0, 1, 0, 1, 0, 1, 0, 1], 3));
        }

        public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
        {
            int n = customers.Length;
            
            int grumpyIndex = -1;
            int localSatisfactionMax = 0;
            for (var i = 0; i <= n - minutes; i++)
            {
                int localSatisfaction = 0;
                for (var j = 0; j < minutes; j++)
                    if (grumpy[i + j] == 1)
                        localSatisfaction += customers[i + j];
                if (localSatisfaction > localSatisfactionMax)
                {
                    localSatisfactionMax = localSatisfaction;
                    grumpyIndex = i;
                }
            }

            if (grumpyIndex > -1)
                for (var i = 0; i < minutes; i++)
                    grumpy[grumpyIndex + i] = 0;

            int maxSatisfaction = 0;
            for (var i = 0; i < n; i++)
                if (grumpy[i] == 0)
                    maxSatisfaction += customers[i];
            
            return maxSatisfaction;
        }
    }
}
