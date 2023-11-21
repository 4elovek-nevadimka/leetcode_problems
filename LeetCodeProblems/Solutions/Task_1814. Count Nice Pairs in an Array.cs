namespace Solutions
{
    internal class Task_1814
    {
        public void Run()
        {
            var nums = new[] { 13, 10, 35, 24, 76, 46 };

            Console.WriteLine(CountNicePairs(nums));
        }

        public void RunTestsForReverse()
        {
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                var nextNum = rand.Next(1000000000);
                Console.WriteLine($"Get reverse for {nextNum} is {Reverse(nextNum)}");
            }
        }

        public int CountNicePairs(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            long nicePairsCounter = 0;
            const int MOD = 1000000007;

            var nicePairsValues = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var diff = nums[i] - Reverse(nums[i]);
                if (!nicePairsValues.ContainsKey(diff))
                {
                    nicePairsValues.Add(diff, 1);
                }
                else
                {
                    nicePairsValues[diff]++;
                }
            }

            foreach (var key in nicePairsValues.Keys)
            {
                if (nicePairsValues[key] > 1)
                {
                    nicePairsCounter +=
                        (long)nicePairsValues[key] * (nicePairsValues[key] - 1) / 2 % MOD;
                }
            }

            return (int)nicePairsCounter % MOD;
        }

        // just simplify solution1
        private int Solution2(int[] nums)
        {
            long nicePairsCounter = 0;
            const int MOD = 1000000007;

            var nicePairsValues = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var diff = nums[i] - Reverse(nums[i]);
                if (!nicePairsValues.ContainsKey(diff))
                {
                    nicePairsValues.Add(diff, 1);
                }
                else
                {
                    nicePairsCounter =
                        (nicePairsCounter + nicePairsValues[diff]) % MOD;
                    nicePairsValues[diff]++;
                }
            }

            return (int)nicePairsCounter;
        }

        private int Reverse(int num)
        {
            var reminder = num;
            var reverseNum = 0;
            while (reminder >= 10)
            {
                reverseNum = (reverseNum + reminder % 10) * 10;
                reminder /= 10;
            }
            reverseNum += reminder;
            return reverseNum;
        }

        #region Another one

        public int CountNicePairs2(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            int result = 0;
            foreach (int n in nums)
            {
                int rev = Reverse2(n);
                int val = n - rev;
                if (counts.ContainsKey(val))
                {
                    result = (result + counts[val]) % 1000000007;
                    counts[val]++;
                }
                else
                {
                    counts[val] = 1;
                }
            }

            return result;
        }

        private int Reverse2(int n)
        {
            int res = 0;
            while (n > 0)
            {
                res = res * 10 + n % 10;
                n /= 10;
            }
            return res;
        }

        #endregion
    }
}
