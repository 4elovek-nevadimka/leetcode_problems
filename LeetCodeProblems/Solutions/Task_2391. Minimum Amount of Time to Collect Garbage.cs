namespace Solutions
{
    internal class Task_2391
    {
        public void Run()
        {
            // var garbage = new[] { "GGMMPPGMP", "M" };
            // var travel = new[] { 39 };
            var garbage = new[] { "G", "P", "GP", "GG" };
            var travel = new[] { 2, 4, 3 };
            // var garbage = new[] { "MMM", "PGM", "GP" };
            // var travel = new[] { 3, 10 };

            Console.WriteLine(GarbageCollection(garbage, travel));
        }

        public int GarbageCollection(string[] garbage, int[] travel)
        {
            return Solution3(garbage, travel);
        }

        private int Solution1(string[] garbage, int[] travel)
        {
            var timeToCollectGarbage = 0;
            int lastM = -1, lastP = -1, lastG = -1;

            // travers for last indexes
            for (var i = garbage.Length - 1; i >= 0; i--)
            {
                if (lastM == -1 && garbage[i].Contains('M'))
                {
                    lastM = i;
                }
                if (lastP == -1 && garbage[i].Contains('P'))
                {
                    lastP = i;
                }
                if (lastG == -1 && garbage[i].Contains('G'))
                {
                    lastG = i;
                }
                if (lastM != -1 && lastP != -1 && lastG != -1)
                    break;
            }

            // counting travers
            for (var i = 0; i < garbage.Length; i++)
            {
                var travelTime = i > 0 ? travel[i - 1] : 0;
                if (lastM >= i)
                {
                    timeToCollectGarbage += CountChars(garbage[i], 'M') + travelTime;
                }
                if (lastP >= i)
                {
                    timeToCollectGarbage += CountChars(garbage[i], 'P') + travelTime;
                }
                if (lastG >= i)
                {
                    timeToCollectGarbage += CountChars(garbage[i], 'G') + travelTime;
                }
            }

            return timeToCollectGarbage;
        }

        private int Solution2(string[] garbage, int[] travel)
        {
            var timeToCollectGarbage = 0;
            var prefixTravel = new int[travel.Length];
            prefixTravel[0] = travel[0];

            // travers for prefix sums
            for (var i = 1; i < travel.Length; i++)
            {
                prefixTravel[i] = prefixTravel[i - 1] + travel[i];
            }

            timeToCollectGarbage += CountGarbage(garbage, prefixTravel, 'M');
            timeToCollectGarbage += CountGarbage(garbage, prefixTravel, 'P');
            timeToCollectGarbage += CountGarbage(garbage, prefixTravel, 'G');

            return timeToCollectGarbage;
        }

        private int Solution3(string[] garbage, int[] travel)
        {
            var prefixTravel = new int[travel.Length];
            prefixTravel[0] = travel[0];
            // travers for prefix sums
            for (var i = 1; i < travel.Length; i++)
            {
                prefixTravel[i] = prefixTravel[i - 1] + travel[i];
            }

            // counting travers
            var garbageOperations = 0;
            int lastM = -1, lastP = -1, lastG = -1;
            for (var i = 0; i < garbage.Length; i++)
            {
                garbageOperations += garbage[i].Length;
                if (garbage[i].Contains('M')) lastM = i;
                if (garbage[i].Contains('P')) lastP = i;
                if (garbage[i].Contains('G')) lastG = i;
            }

            return garbageOperations
                + (lastM > 0 ? prefixTravel[lastM - 1] : 0)
                + (lastP > 0 ? prefixTravel[lastP - 1] : 0)
                + (lastG > 0 ? prefixTravel[lastG - 1] : 0);
        }

        private int CountGarbage(string[] garbage, int[] prefixTravel, char garbageType)
        {
            var lastIndex = -1;
            var garbageTime = 0;
            for (var i = 0; i < garbage.Length; i++)
            {
                if (garbage[i].Contains(garbageType))
                {
                    garbageTime += CountChars(garbage[i], garbageType);
                    lastIndex = i;
                }
            }
            garbageTime += lastIndex > 0 ? prefixTravel[lastIndex - 1] : 0;
            return garbageTime;
        }

        private int CountChars(string source, char toFind)
        {
            int count = 0;
            for (int n = 0; n < source.Length; n++)
            {
                if (source[n] == toFind)
                    count++;
            }
            return count;
        }
    }
}
