namespace Solutions.Arrays
{
    internal class Task_1578
    {
        // #Array #String #Dynamic Programming #Greedy

        public void Run()
        {
            Console.WriteLine(MinCost("aabaa", new[] { 1, 2, 3, 4, 1 }));
        }

        public int MinCost(string colors, int[] neededTime)
        {
            var lastColor = colors[0];
            var curMaxNeededTime = neededTime[0];
            var subTotalNeededTime = neededTime[0];
            var totalNeededTime = 0;

            for (var i = 1; i < colors.Length; i++)
            {
                var curNeededTime = neededTime[i];
                if (colors[i] == lastColor)
                {
                    curMaxNeededTime = Math.Max(curMaxNeededTime, curNeededTime);
                    subTotalNeededTime += curNeededTime;
                }
                else
                {
                    totalNeededTime += subTotalNeededTime - curMaxNeededTime;
                    
                    curMaxNeededTime = curNeededTime;
                    subTotalNeededTime = curNeededTime;
                }
                lastColor = colors[i];
            }
            totalNeededTime += subTotalNeededTime - curMaxNeededTime;

            return totalNeededTime;
        }
    }
}
