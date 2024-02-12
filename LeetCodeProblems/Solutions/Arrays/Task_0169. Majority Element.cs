namespace Solutions.Arrays
{
    internal class Task_0169
    {
        // #Array #Hash Table #Divide and Conquer #Sorting #Counting

        public int MajorityElement(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (int x in nums)
            {
                if (!dic.ContainsKey(x))
                    dic[x] = 1;
                else
                    dic[x]++;
            }

            foreach (var x in dic.Keys)
                if (dic[x] > nums.Length / 2)
                    return x;

            return 0;
        }
    }
}
