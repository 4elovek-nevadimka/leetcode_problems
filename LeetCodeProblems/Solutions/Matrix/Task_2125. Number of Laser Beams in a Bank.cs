namespace Solutions.Matrix
{
    internal class Task_2125
    {
        public int NumberOfBeams(string[] bank)
        {
            int rowOne = 0, rowTwo = 0;
            int numberOfBeams = 0;

            foreach (var c in bank[0])
            {
                if (c == '1')
                {
                    rowOne++;
                }
            }    

            for (var i = 1; i < bank.Length; i++)
            {
                foreach (var c in bank[i])
                {
                    if (c == '1')
                    {
                        rowTwo++;
                    }
                }
                if (rowTwo != 0)
                {
                    numberOfBeams += rowOne * rowTwo;
                    rowOne = rowTwo;
                    rowTwo = 0;
                }
            }

            return numberOfBeams;
        }
    }
}
