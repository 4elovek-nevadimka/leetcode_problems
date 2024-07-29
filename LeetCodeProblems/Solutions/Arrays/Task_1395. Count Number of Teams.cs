namespace Solutions.Arrays
{
    internal class Task_1395
    {
        // #Array #Dynamic Programming #Binary Indexed Tree

        public int NumTeams(int[] rating)
        {
            var teamsCount = 0;
            var n = rating.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (rating[i] > rating[j])
                    {
                        for (var k = j + 1; k < n; k++)
                        {
                            if (rating[j] > rating[k])
                                teamsCount++;
                        }
                    }
                }
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (rating[i] < rating[j])
                    {
                        for (var k = j + 1; k < n; k++)
                        {
                            if (rating[j] < rating[k])
                                teamsCount++;
                        }
                    }
                }
            }

            return teamsCount;
        }
    }
}
