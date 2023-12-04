using System.Diagnostics.CodeAnalysis;

namespace Solutions
{
    internal class Task_2264
    {
        public void Run()
        {
            Console.WriteLine($"Answer for 6777133339 is {LargestGoodInteger("6777133339")}");
            Console.WriteLine($"Answer for 2300019 is {LargestGoodInteger("2300019")}");
            Console.WriteLine($"Answer for 42352338 is {LargestGoodInteger("42352338")}");
            Console.WriteLine($"Answer for 111222333 is {LargestGoodInteger("111222333")}");
        }

        public string LargestGoodInteger(string num)
        {
            int maxNumCode = 0, seqCounter = 0;
            for (var i = 1; i < num.Length; i++)
            {
                if (maxNumCode > 0)
                {
                    if (maxNumCode >= num[i]) continue;
                }
                if (num[i] == num[i - 1])
                {
                    seqCounter++;
                    if (seqCounter == 2)
                    {
                        maxNumCode = num[i];
                    }
                }
                else
                {
                    seqCounter = 0;
                }
            }

            return maxNumCode == 0 ? "" : new string((char)maxNumCode, 3);
        }
    }
}
