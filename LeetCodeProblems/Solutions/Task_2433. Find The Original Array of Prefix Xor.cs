namespace Solutions
{
    internal class Task_2433
    {
        public void Run()
        {
            var pref = new[] { 5, 2, 0, 3, 1 };
            // var pref = new[] { 13 };
            var result = FindArray(pref);
            Array.ForEach(result, Console.WriteLine);
        }

        public int[] FindArray(int[] pref)
        {
            return Solution2(pref);
        }

        private int[] Solution2(int[] pref)
        {
            for (var i = pref.Length - 1; i > 0; i--)
            {
                pref[i] = pref[i - 1] ^ pref[i];
            }
            return pref;
        }

        private int[] Solution1(int[] pref)
        {
            var n = pref.Length;
            var result = new int[n];
            result[0] = pref[0];
            for (var i = 1; i < n; i++)
            {
                result[i] = pref[i - 1] ^ pref[i];
            }
            return result;
        }
    }
}
