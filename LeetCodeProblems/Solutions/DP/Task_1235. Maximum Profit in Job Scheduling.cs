namespace Solutions.DP
{
    internal class Task_1235
    {
        private record Job(int StartTime, int EndTime, int Profit);

        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            var jobs = new List<Job>();
            for (var i = 0; i < startTime.Length; i++)
            {
                jobs.Add(new Job(startTime[i], endTime[i], profit[i]));
            }

            jobs.Sort((job, job1) => job.EndTime - job1.EndTime);

            var dp = new List<int>();
            dp.Add(jobs[0].Profit);

            for (int i = 1; i < startTime.Length; i++)
            {
                dp.Add(Math.Max(dp[i - 1], jobs[i].Profit));

                for (int j = i - 1; j >= 0; j--)
                {
                    if (jobs[j].EndTime <= jobs[i].StartTime)
                    {
                        dp[i] = Math.Max(dp[i], jobs[i].Profit + dp[j]);
                        break;
                    }
                }
            }

            return dp[startTime.Length - 1];
        }
    }
}