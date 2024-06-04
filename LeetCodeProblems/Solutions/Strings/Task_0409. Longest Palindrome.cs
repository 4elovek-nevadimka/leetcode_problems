namespace Solutions.Strings
{
    internal class Task_0409
    {
        // #Hash Table #String #Greedy

        public int LongestPalindrome(string s)
        {
            var dic = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!dic.ContainsKey(c))
                    dic[c] = 0;
                dic[c]++;
            }

            var longest = 0;
            var addOne = false;
            foreach (var key in dic.Keys)
            {

                if (int.IsEvenInteger(dic[key]))
                    longest += dic[key];
                else
                {
                    if (!addOne) addOne = true;
                    longest += dic[key] - 1;
                }
            }
            if (addOne)
                longest++;

            return longest;
        }
    }
}
