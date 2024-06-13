namespace Solutions.Arrays
{
    internal class Task_2037
    {
        // #Array #Greedy #Sorting

        public int MinMovesToSeat(int[] seats, int[] students)
        {
            Array.Sort(seats);
            Array.Sort(students);

            var moves = 0;
            for (var i = 0; i < seats.Length; i++)
                moves += Math.Abs(seats[i] - students[i]);

            return moves;
        }
    }
}
