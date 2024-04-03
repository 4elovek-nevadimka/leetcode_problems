namespace Solutions.Matrix
{
    internal class Task_0079
    {
        // #Array #String #Backtracking #Matrix

        public void Run()
        {
            Console.WriteLine(Exist(
                [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCCED"));
            Console.WriteLine(Exist(
                [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "SEE"));
            Console.WriteLine(Exist(
                [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCB"));
            Console.WriteLine(Exist(
                [['A', 'B', 'C', 'E'], ['S', 'F', 'E', 'S'], ['A', 'D', 'E', 'E']], "ABCEFSADEESE"));
            Console.WriteLine(Exist([['A']], "A"));
        }

        private readonly int[][] _directions = [[0, -1], [0, 1], [-1, 0], [1, 0]];

        public bool Exist(char[][] board, string word)
        {
            for (var row = 0; row < board.Length; row++)
            {
                for (var col = 0; col < board[row].Length; col++)
                {
                    if (Search(row, col, board, 0, word))
                        return true;
                }
            }
            return false;
        }

        private bool Search(int row, int col, char[][] board, int index, string word)
        {
            if (board[row][col] == word[index])
            {
                if (index == word.Length - 1)
                    return true;

                board[row][col] = '-';
                foreach (var shift in _directions)
                {
                    if (row + shift[0] >= 0 && row + shift[0] < board.Length 
                        && col + shift[1] >= 0 && col + shift[1] < board[0].Length)
                    {
                        if (Search(row + shift[0], col + shift[1], board, index + 1, word))
                            return true;
                    }
                }
                board[row][col] = word[index];
            }

            return false;
        }
    }
}
