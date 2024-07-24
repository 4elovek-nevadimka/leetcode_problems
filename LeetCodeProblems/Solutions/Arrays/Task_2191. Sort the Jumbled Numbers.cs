namespace Solutions.Arrays
{
    internal class Task_2191
    {
        // #Array #Sorting

        public void Run()
        {
            Console.WriteLine("----------");
            var result = SortJumbled([8, 9, 4, 0, 2, 1, 3, 5, 7, 6], [991, 338, 38]);
            Array.ForEach(result, Console.Write);

            Console.WriteLine();
            Console.WriteLine("----------");
            result = SortJumbled([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], [789, 456, 123]);
            Array.ForEach(result, Console.Write);
        }

        public int[] SortJumbled(int[] mapping, int[] nums)
        {
            int GetMappedNum(int oldNum)
            {
                if (oldNum == 0)
                    return mapping[0];
                var stack = new Stack<int>();
                while (oldNum > 0)
                {
                    stack.Push(oldNum % 10);
                    oldNum /= 10;
                }

                var newNum = 0;
                while (stack.Count > 1)
                    newNum = (newNum + mapping[stack.Pop()]) * 10;

                newNum += mapping[stack.Pop()];

                // Console.WriteLine(newNum);
                return newNum;
            }

            var pairs = new List<(int original, int mapped)>();
            foreach (int num in nums)
                pairs.Add((num, GetMappedNum(num)));

            pairs.Sort((a, b) => a.mapped.CompareTo(b.mapped));

            var sortedNums = new int[nums.Length];
            for (int i = 0; i < pairs.Count; i++)
                sortedNums[i] = pairs[i].original;

            return sortedNums;
        }
    }
}
