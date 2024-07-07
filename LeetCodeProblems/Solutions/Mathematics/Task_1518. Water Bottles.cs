namespace Solutions.Mathematics
{
    internal class Task_1518
    {
        // #Math #Simulation

        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int waterBottles = 0;
            while (numBottles >= numExchange)
            {
                int divBottles = numBottles / numExchange;

                waterBottles += numExchange * divBottles;
                numBottles -= numExchange * divBottles;

                numBottles += divBottles;
            }

            return waterBottles + numBottles;
        }
    }
}
