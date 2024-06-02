namespace Solutions.Strings
{
    internal class Task_0344
    {
        // #String #Two Pointers

        public void ReverseString(char[] s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
                (s[left], s[right]) = (s[right--], s[left++]);
        }
    }
}
