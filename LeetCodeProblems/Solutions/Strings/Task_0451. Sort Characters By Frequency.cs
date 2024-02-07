using System.Text;

namespace Solutions.Strings
{
    internal class Task_0451
    {
        // #Hash Table #String #Sorting #Heap(Priority Queue) #Bucket Sort #Counting

        public void Run()
        {
            Console.WriteLine(FrequencySort("tree"));
        }

        public string FrequencySort(string s)
        {
            var dic = new Dictionary<char, int>();
            foreach (var c in s)
                if (!dic.ContainsKey(c))
                    dic[c] = 1;
                else
                    dic[c]++;

            var str = new StringBuilder();
            foreach (var pair in dic.OrderByDescending(x => x.Value))
            {
                str.Append(pair.Key, pair.Value);
            }

            return str.ToString();
        }
    }
}
