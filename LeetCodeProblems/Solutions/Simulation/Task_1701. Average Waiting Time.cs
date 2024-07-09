namespace Solutions.Simulation
{
    internal class Task_1701
    {
        // #Array #Simulation

        public void Run()
        {
            Console.WriteLine(AverageWaitingTime([[5, 2], [5, 4], [10, 3], [20, 1]]));
        }

        public double AverageWaitingTime(int[][] customers)
        {
            double waitingSum = 0, time = customers[0][0];
            foreach (var customer in customers)
            {
                if (time < customer[0])
                    time = customer[0];
                time += customer[1];
                waitingSum += time - customer[0];
            }

            return waitingSum / customers.Length;
        }
    }
}
