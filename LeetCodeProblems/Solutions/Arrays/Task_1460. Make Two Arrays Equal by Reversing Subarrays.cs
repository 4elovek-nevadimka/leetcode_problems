namespace Solutions.Arrays
{
    internal class Task_1460
    {
        // #Array #Hash Table #Sorting

        public bool CanBeEqual(int[] target, int[] arr)
        {
            return Solution1(target, arr);
        }

        private bool Solution1(int[] target, int[] arr)
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

        private bool Solution2(int[] target, int[] arr)
        {
            var dic = new Dictionary<int, int>();
            foreach (var item in target)
                if (dic.ContainsKey(item))
                    dic[item]++;
                else
                    dic[item] = 1;

            foreach (var item in arr)
                if (dic.ContainsKey(item))
                    dic[item]--;
                else
                    return false;

            foreach (var key in dic.Keys)
                if (dic[key] != 0)
                    return false;

            return true;
        }
    }
}
