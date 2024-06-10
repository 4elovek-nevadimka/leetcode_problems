namespace Solutions.Arrays
{
    internal class Task_1051
    {
        // #Array #Sorting #Counting Sort

        public int HeightChecker(int[] heights)
        {
            var maxHeight = 0;
            foreach (var height in heights)
                if (height > maxHeight)
                    maxHeight = height;

            var helpArr = new int[maxHeight + 1];
            foreach (var height in heights)
                helpArr[height]++;

            var index = 0;
            var diffCounter = 0;
            for (var i = 0; i < helpArr.Length; i++)
            {
                for (var j = 0; j < helpArr[i]; j++)
                {
                    if (i != heights[index])
                        diffCounter++;
                    index++;
                }
            }

            return diffCounter;
        }
    }
}
