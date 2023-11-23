namespace Solutions
{
    internal class Task_1630
    {
        public void Run()
        {
            var nums = new[] { 4, 6, 5, 9, 3, 7 };
            var l = new[] { 0, 0, 2 };
            var r = new[] { 2, 3, 5 };

            var result = CheckArithmeticSubarrays(nums, l, r);
            Array.ForEach(result.ToArray(), Console.WriteLine);
        }

        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            var n = l.Length;
            var result = new bool[n];
            for (var i = 0; i < n; i++)
            {
                // create subarray
                var tmpArrSize = r[i] - l[i] + 1;
                var tmpArr = new int[tmpArrSize];
                for (var j = 0; j < tmpArrSize; j++)
                {
                    tmpArr[j] = nums[l[i] + j];
                }
                // check it
                result[i] = true;
                Array.Sort(tmpArr);
                var diff = tmpArr[1] - tmpArr[0];
                for (var k = 1; k < tmpArrSize - 1; k++)
                {
                    if (tmpArr[k + 1] - tmpArr[k] != diff)
                    {
                        result[i] = false;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
