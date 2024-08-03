namespace Solutions.Arrays
{
    internal class Task_1460
    {
        // #Array #Hash Table #Sorting

        public bool CanBeEqual(int[] target, int[] arr)
        {
            var tmpArr = new int[1001];
            foreach (var item in target)
                tmpArr[item]++;

            foreach (var item in arr)
                if (--tmpArr[item] < 0)
                    return false;

            foreach (var item in tmpArr)
                if (item > 0)
                    return false;

            return true;
        }
    }
}
