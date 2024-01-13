namespace Solutions.Arrays
{
    internal class Task_1512
    {
        // #Array #Hash Table #Math #Counting

        public int NumIdenticalPairs(int[] nums)
        {
            return Solution3(nums);
        }

        private int Solution1(int[] nums)
        {
            var goodPairs = 0;
            var pairs = new Dictionary<int, ICollection<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (!pairs.ContainsKey(num))
                {
                    pairs.Add(num, new HashSet<int>());
                }
                pairs[num].Add(i);
            }

            foreach (int num in pairs.Keys)
            {
                var indexes = pairs[num];
                for (var i = 0; i < indexes.Count; i++)
                {
                    for (var j = i + 1; j < indexes.Count; j++)
                    {
                        goodPairs++;
                    }
                }
            }

            return goodPairs;
        }

        private int Solution2(int[] nums)
        {
            var goodPairsCounter = 0;
            var digitsCounter = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!digitsCounter.ContainsKey(num))
                {
                    digitsCounter.Add(num, 1);
                }
                else
                {
                    digitsCounter[num]++;
                }
            }

            foreach (int num in digitsCounter.Keys)
            {
                goodPairsCounter += 
                    digitsCounter[num] * (digitsCounter[num] - 1) / 2;
            }

            return goodPairsCounter;
        }

        private int Solution3(int[] nums)
        {
            var goodPairsCounter = 0;
            var digitsCounter = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!digitsCounter.ContainsKey(num))
                {
                    digitsCounter.Add(num, 1);
                }
                else
                {
                    goodPairsCounter += digitsCounter[num]++;
                }
            }

            return goodPairsCounter;
        }
    }
}
