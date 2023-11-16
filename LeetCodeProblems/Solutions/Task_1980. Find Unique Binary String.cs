using System.Text;

namespace Solutions
{
    internal class Task_1980
    {
        public void Run()
        {
            var nums = new[] { "00", "01" };
            Console.WriteLine(FindDifferentBinaryString(nums));
        }

        public string FindDifferentBinaryString(string[] nums)
        {
            return Solution1(nums);
        }

        // Cantor's diagonal
        public string Solution1(string[] nums)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < nums.Length; i++)
            {
                sb.Append(nums[i][i] == '0' ? '1' : '0');
            }
            return sb.ToString();
        }

        // hash set
        public string Solution2(string[] nums)
        {
            var hash = new HashSet<int>();
            foreach (var binaryNum in nums)
            {
                hash.Add(Convert.ToInt32(binaryNum, 2));
            }

            var power = nums[0].Length;
            var maxValue = Math.Pow(2, power);
            for (var i = 0; i < maxValue; i++)
            {
                if (!hash.Contains(i))
                    return Convert.ToString(i, 2).PadLeft(power, '0');
            }

            // not possible ?
            return "";
        }
    }
}
