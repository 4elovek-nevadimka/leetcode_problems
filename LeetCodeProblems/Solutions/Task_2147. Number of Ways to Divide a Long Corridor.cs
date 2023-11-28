namespace Solutions
{
    internal class Task_2147
    {
        public void Run()
        {
            var corridor = "SSPPPSS";
            Console.WriteLine(NumberOfWays(corridor));
        }

        public int NumberOfWays(string corridor)
        {
            const int MOD = 1000000000 + 7;

            var startIndex = GetStartIndex(corridor);
            // less than 2 seats in the corridor
            if (startIndex == 0) return 0;

            var endIndex = GetEndIndex(startIndex, corridor);
            // less than 4 seats in the corridor
            if (endIndex == 0) return 1;
            
            long total = 1;
            var seatCounter = 0;
            var curSeqOfPlants = 0;
            for (var i = startIndex; i < endIndex; i++)
            {
                if (corridor[i] == 'S')
                {
                    seatCounter++;
                    if (seatCounter == 2)
                    {
                        seatCounter = 0;
                        total = total * (curSeqOfPlants + 1) % MOD;
                        curSeqOfPlants = 0;
                    }
                }
                else
                {
                    if (seatCounter != 1)
                    {
                        curSeqOfPlants++;
                    }
                }
            }
            // sub area ends with plants
            if (curSeqOfPlants > 0)
            {
                total = total * (curSeqOfPlants + 1) % MOD;
            }
            // if the number of seats is odd return 0
            return seatCounter == 1 ? 0 : (int)total;
        }

        private int GetStartIndex(string corridor)
        {
            var seatCounter = 0;
            for (var i = 0; i < corridor.Length; i++)
            {
                if (corridor[i] == 'S')
                {
                    seatCounter++;
                    if (seatCounter == 2)
                    {
                        return i + 1;
                    }
                }
            }
            return 0;
        }

        private int GetEndIndex(int startIndex, string corridor)
        {
            var seatCounter = 0;
            for (var i = corridor.Length - 1; i > startIndex; i--)
            {
                if (corridor[i] == 'S')
                {
                    seatCounter++;
                    if (seatCounter == 2)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
    }
}
