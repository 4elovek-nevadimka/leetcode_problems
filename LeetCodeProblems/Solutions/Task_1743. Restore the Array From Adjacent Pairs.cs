using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    internal class Task_1743
    {
        public void Run()
        {
            var adjacentPairs = new int[][] { new[] { 2, 1 }, new[] { 3, 4 }, new[] { 3, 2 } };
            var result = RestoreArray(adjacentPairs);
            Array.ForEach(result, Console.WriteLine);
        }
        public int[] RestoreArray(int[][] adjacentPairs)
        {
            var hash = new Dictionary<int, List<int[]>>();
            var originalLength = adjacentPairs.Length + 1;
            var original = new int[originalLength];

            int pairValue, currentIndex = 0;
            foreach (var pair in adjacentPairs)
            {
                pairValue = pair[0];
                if (!hash.ContainsKey(pairValue))
                {
                    hash.Add(pairValue, new List<int[]>());
                }
                hash[pairValue].Add(pair);

                pairValue = pair[1];
                if (!hash.ContainsKey(pairValue))
                {
                    hash.Add(pairValue, new List<int[]>());
                }
                hash[pairValue].Add(pair);
            }

            // get first pair
            int firstKey = 0;
            foreach (var key in hash.Keys)
            {
                if (hash[key].Count == 1)
                {
                    firstKey = key;
                    break;
                }
            }
            original[currentIndex++] = firstKey;
            var firstArr = hash[firstKey].First();
            original[currentIndex++] = 
                firstArr[0] != firstKey ? firstArr[0] : firstArr[1];

            while (currentIndex < originalLength)
            {
                var list = hash[original[currentIndex - 1]];
                foreach (var arr in list)
                {
                    if (arr[0] != original[currentIndex - 1] && arr[0] != original[currentIndex - 2])
                    {
                        original[currentIndex++] = arr[0];
                        break;
                    }
                    if (arr[1] != original[currentIndex - 1] && arr[1] != original[currentIndex - 2])
                    {
                        original[currentIndex++] = arr[1];
                        break;
                    }
                }
            }

            return original;
        }
    }
}
