using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Strings
{
    internal class Task_1653
    {
        // #String #Dynamic Programming #Stack

        public int MinimumDeletions(string s)
        {
            int n = s.Length;
            int[] countA = new int[n];
            int[] countB = new int[n];
            int bCount = 0;

            // First pass: compute count_b which stores the number of
            // 'b' characters to the left of the current position.
            for (int i = 0; i < n; i++)
            {
                countB[i] = bCount;
                if (s[i] == 'b') bCount++;
            }

            int aCount = 0;
            // Second pass: compute count_a which stores the number of
            // 'a' characters to the right of the current position
            for (int i = n - 1; i >= 0; i--)
            {
                countA[i] = aCount;
                if (s[i] == 'a') aCount++;
            }

            int minDeletions = n;
            // Third pass: iterate through the string to find the minimum deletions
            for (int i = 0; i < n; i++)
            {
                minDeletions = Math.Min(minDeletions, countA[i] + countB[i]);
            }

            return minDeletions;
        }
    }
}
