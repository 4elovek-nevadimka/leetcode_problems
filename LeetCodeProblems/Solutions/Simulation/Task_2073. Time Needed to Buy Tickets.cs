namespace Solutions.Simulation
{
    internal class Task_2073
    {
        // #Array #Queue #Simulation

        public int TimeRequiredToBuy(int[] tickets, int k)
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
    }
}
