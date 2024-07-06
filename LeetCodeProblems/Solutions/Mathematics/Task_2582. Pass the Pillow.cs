namespace Solutions.Mathematics
{
    internal class Task_2582
    {
        // #Math #Simulation

        public int PassThePillow(int n, int time)
        {
            if (time < n)
                return time + 1;

            if (time == n)
                return n - 1;

            var div = time / (n - 1);
            var rest = time % (n - 1);
            if (div % 2 == 0)
                return rest + 1;
            else
                return n - rest;
        }
    }
}
