namespace Solutions.Arrays
{
    internal class Task_1051
    {
        // #Array #Sorting #Counting Sort

        public int HeightChecker(int[] heights)
        {
            var sortedArr = new int[heights.Length];
            heights.CopyTo(sortedArr, 0);

            Array.Sort(sortedArr);
            var diffCounter = 0;

            for (var i = 0; i < heights.Length; i++)
                if (heights[i] != sortedArr[i])
                    diffCounter++;

            return diffCounter;
        }
    }
}
