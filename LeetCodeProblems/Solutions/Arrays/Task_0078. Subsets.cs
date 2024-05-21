namespace Solutions.Arrays
{
    internal class Task_0078
    {
        // #Array #Backtracking #Bit Manipulation

        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>> { ([]) };

            foreach (int num in nums)
            {
                var currentSubsetsCount = result.Count;
                for (var i = 0; i < currentSubsetsCount; i++)
                {
                    var newSubset = new List<int>(result[i]) { num };
                    result.Add(newSubset);
                }
            }

            return result;
        }
    }
}
