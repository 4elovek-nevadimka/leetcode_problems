namespace Solutions.Arrays
{
    internal class Task_0881
    {
        // #Array #Two Pointers #Greedy #Sorting

        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int boatsCount = 0;
            int left = 0, right = people.Length - 1;

            while (left <= right)
            {
                if (people[left] + people[right] <= limit)
                {
                    left++;
                    right--;
                    boatsCount++;
                }
                else
                {
                    right--;
                    boatsCount++;
                }
            }

            return boatsCount;
        }
    }
}
