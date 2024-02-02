using System.Numerics;

namespace Solutions.Enumeration
{
    internal class Task_1291
    {
        // #Enumeration

        // Input: low = 1000, high = 13000
        // Output: [1234,2345,3456,4567,5678,6789,12345]

        public void Run()
        {
            Console.WriteLine(SequentialDigits(1000, 13000));
        }

        public IList<int> SequentialDigits(int low, int high)
        {
            int left = Deconstruct(low), right = Deconstruct(high);
            var sequentialDigits = new List<int>();
            var s = "123456789";

            for (var numberOfDigits = left; numberOfDigits < right + 1; numberOfDigits++)
            {
                var to = 9 - numberOfDigits + 1;
                for (var from = 0; from < to; from++)
                {
                    if (int.TryParse(s.AsSpan(from, numberOfDigits), out int digit))
                    {
                        if (digit >= low && digit <= high)
                            sequentialDigits.Add(digit);
                    }
                }
            }

            return sequentialDigits;
        }

        private int Deconstruct(int n)
        {
            var counter = 0;
            while (n >= 10)
            {
                n /= 10;
                counter++;
            }
            return ++counter;
        }
    }
}
