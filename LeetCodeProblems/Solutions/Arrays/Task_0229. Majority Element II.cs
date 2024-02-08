namespace Solutions.Arrays
{
    public class Task_0229
    {
        // #Array #Hash Table #Sorting #Counting

        public IList<int> MajorityElement(int[] nums)
        {
            var appearTimes = nums.Length / 3;
            var appears = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (appears.ContainsKey(num))
                {
                    appears[num]++;
                }
                else
                {
                    appears.Add(num, 1);
                }
            }

            return appears.Where(x => x.Value > appearTimes).Select(x => x.Key).ToList();
        }

        public void Run()
        {
            // expected 3
            var nums = new[] { 3, 2, 3 };

            var result = MajorityElement(nums);
            Console.WriteLine(result);
        }
    }
}
