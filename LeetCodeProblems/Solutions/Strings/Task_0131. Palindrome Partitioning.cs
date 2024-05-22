namespace Solutions.Strings
{
    internal class Task_0131
    {
        // #String #Dynamic Programming #Backtracking

        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            var currentPartition = new List<string>();

            PartitionHelper(s, 0, currentPartition, result);

            return result;
        }

        private void PartitionHelper(string s, int start, IList<string> currentPartition, IList<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(currentPartition));
                return;
            }

            for (var end = start; end < s.Length; end++)
            {
                if (IsPalindrome(s, start, end))
                {
                    currentPartition.Add(s.Substring(start, end - start + 1));
                    PartitionHelper(s, end + 1, currentPartition, result);

                    currentPartition.RemoveAt(currentPartition.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
                if (s[left++] != s[right--])
                    return false;

            return true;
        }
    }
}
