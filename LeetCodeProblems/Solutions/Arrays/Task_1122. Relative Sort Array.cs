namespace Solutions.Arrays
{
    internal class Task_1122
    {
        // #Array #Hash Table #Sorting #Counting Sort

        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var maxValue = 0;
            foreach (var val in arr1)
                if (val > maxValue)
                    maxValue = val;

            var helpArr = new int[maxValue + 1];
            foreach (var val in arr1)
                helpArr[val]++;

            var index = 0;
            foreach (var val in arr2)
                while (helpArr[val]-- > 0)
                    arr1[index++] = val;

            for (var i = 0; i < helpArr.Length; i++)
                while (helpArr[i]-- > 0)
                    arr1[index++] = i;

            return arr1;
        }
    }
}
