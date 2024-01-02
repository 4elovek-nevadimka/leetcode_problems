namespace Solutions.Arrays
{
    internal class Task_2610
    {
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            return Solution3(nums);
        }

        private IList<IList<int>> Solution1(int[] nums)
        {
            var result = new List<IList<int>>();
            var dict = new Dictionary<int, int>();
            foreach (var i in nums)
            {
                if (!dict.ContainsKey(i))
                    dict.Add(i, 1);
                else
                    dict[i]++;
            }

            while (true)
            {
                var tempList = new List<int>();
                foreach (var i in dict.Keys)
                {
                    if (dict[i] > 0)
                    {
                        tempList.Add(i);
                        dict[i]--;
                    }
                }
                if (tempList.Count > 0)
                    result.Add(tempList);
                else
                    break;
            }

            return result;
        }

        private IList<IList<int>> Solution2(int[] nums)
        {
            var result = new List<IList<int>>();
            var tempList = new List<int>(nums);
            while (tempList.Count != 0)
            {
                var hashSet = new HashSet<int>(tempList);
                result.Add(hashSet.ToList());
                foreach (var num in hashSet)
                {
                    tempList.Remove(num);
                }
            }
            return result;
        }

        private IList<IList<int>> Solution3(int[] nums)
        {
            var result = new List<IList<int>> { new List<int>() };
            var curListIndex = 0;
            foreach (var num in nums)
            {
                if (result[curListIndex].Contains(num))
                {
                    while (true)
                    {
                        curListIndex++;
                        if (curListIndex == result.Count)
                        {
                            result.Add(new List<int>());
                        }
                        if (!result[curListIndex].Contains(num))
                        {
                            result[curListIndex].Add(num);
                            curListIndex = 0;
                            break;
                        }
                    }
                }
                else
                {
                    result[curListIndex].Add(num);
                }
            }
            return result;
        }

    }
}
