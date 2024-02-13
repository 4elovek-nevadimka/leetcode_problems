namespace Solutions.Arrays
{
    public class Task_0229
    {
        // #Array #Hash Table #Sorting #Counting

        public void Run()
        {
            // expected 3
            var nums = new[] { 3, 2, 3 };
            // expected 0
            // var nums = new[] { 0, 0, 0 };

            var result = MajorityElement(nums);
            Console.WriteLine(result);
        }

        public IList<int> MajorityElement(int[] nums)
        {
            return Solution2(nums);
        }

        private IList<int> Solution1(int[] nums)
        {
            var appearTimes = nums.Length / 3;
            var appears = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (appears.ContainsKey(num))
                {
                    appears[num]++;
                }
                else
                {
                    appears.Add(num, 1);
                }
            }

            return appears.Where(x => x.Value > appearTimes).Select(x => x.Key).ToList();
        }

        // Based on Boyer Moore majority voting algorithm
        private IList<int> Solution2(int[] nums)
        {
            var k = 3;
            var candidates = new int[k - 1];
            var candidatesCount = new int[k - 1];

            foreach (var num in nums)
            {
                var exists = false;
                for (var i = 0; i < k - 1; i++)
                {
                    if (candidates[i] == num)
                    {
                        candidatesCount[i]++;
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    for (var i = 0; i < k - 1; i++)
                    {
                        if (candidatesCount[i] == 0)
                        {
                            candidates[i] = num;
                            candidatesCount[i] = 1;
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        for (var i = 0; i < k - 1; i++)
                        {
                            candidatesCount[i]--;
                        }
                    }
                }
            }

            var result = new List<int>();
            for (var i = 0; i < k - 1; i++)
            {
                if (result.Contains(candidates[i]))
                    continue;

                var count = 0;
                foreach (var num in nums)
                {
                    if (num == candidates[i])
                        count++;
                }

                if (count > nums.Length / k)
                    result.Add(candidates[i]);
            }

            return result;
        }
    }
}
