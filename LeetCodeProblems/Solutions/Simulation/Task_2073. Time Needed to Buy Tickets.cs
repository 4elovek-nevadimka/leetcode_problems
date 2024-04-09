namespace Solutions.Simulation
{
    internal class Task_2073
    {
        // #Array #Queue #Simulation

        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            return Solution2(tickets, k);
        }

        private int Solution1(int[] tickets, int k)
        {
            var time = 0;
            while (tickets[k] > 0)
            {
                for (var i = 0; i < tickets.Length; i++)
                {
                    if (tickets[i] > 0)
                    {
                        time++;
                        tickets[i]--;
                    }
                    if (i == k && tickets[i] == 0)
                        break;
                }
            }

            return time;
        }

        private int Solution2(int[] tickets, int k)
        {
            if (tickets[k] == 1)
                return k + 1;
            
            var time = 0;
            for (var i = 0; i < tickets.Length; i++)
                time += Math.Min(tickets[i], tickets[k]);

            for (var i = k + 1; i < tickets.Length; i++)
                if (tickets[k] <= tickets[i])
                    time--;

            return time;
        }
    }
}
