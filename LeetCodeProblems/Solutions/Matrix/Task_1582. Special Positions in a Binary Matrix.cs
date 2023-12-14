namespace Solutions.Matrix
{
    internal class Task_1582
    {
        // #Array #Matrix 
        public void Run()
        {
            var matrix = new int[][] { 
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new[] { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                new[] { 0, 0, 0, 0, 0, 0, 1, 0 }, 
                new[] { 0, 1, 0, 0, 0, 0, 1, 0 }, 
                new[] { 0, 1, 0, 0, 0, 0, 0, 0 } };
            
            Console.WriteLine(NumSpecial(matrix));
        }

        public int NumSpecial(int[][] mat)
        {
            return Solution2(mat);
        }

        private int Solution1(int[][] mat)
        {
            int specialNumCount = 0;
            int rowsCount = mat.Length, colsCount = mat[0].Length;
            for (var i = 0; i < rowsCount; i++)
            {
                int colToCheck = -1;
                for (var j = 0; j < colsCount; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        if (colToCheck != -1)
                        {
                            colToCheck = -1;
                            break;
                        }
                        colToCheck = j;
                    }
                }

                if (colToCheck > -1)
                {
                    int occurInCol = 0;
                    for (var k = 0; k < rowsCount; k++)
                    {
                        if (mat[k][colToCheck] == 1)
                        {
                            occurInCol++;
                            if (occurInCol > 1)
                            {
                                break;
                            }
                        }
                    }
                    if (occurInCol == 1)
                    {
                        specialNumCount++;
                    }
                }
            }

            return specialNumCount;
        }

        private int Solution2(int[][] mat)
        {
            int rowsCount = mat.Length, colsCount = mat[0].Length;
            var rowsArr = new int[rowsCount];
            var colsArr = new int[colsCount];
            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < colsCount; j++)
                {
                    rowsArr[i] += mat[i][j];
                    colsArr[j] += mat[i][j];
                }
            }

            var specialNumsCount = 0;
            for (var i = 0; i < rowsCount; i++)
            {
                if (rowsArr[i] != 1) 
                    continue;

                for (var j = 0; j < colsCount; j++)
                {
                    if (mat[i][j] == 1 && colsArr[j] == 1) 
                        specialNumsCount++;
                }
            }

            return specialNumsCount;
        }

    }
}
