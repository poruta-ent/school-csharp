using System;

namespace Collections
{
    public class TicTacToeGame
    {
        //public Square[][] _board =
        //{
        //    new Square[3],
        //    new Square[3],
        //    new Square[3]
        //};

        public Square[,] _board = new Square[3,3];

        public void PlayGame()
        {
            Player player = Player.Crosses;
            
            bool @continue = true;
            while (@continue)
            {
                DisplayBoard();
                @continue = PlayMove(player);
                if (!@continue)
                {  
                    return;
                }
                player = 3 - player;
            }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"\t{_board[i,j]}");
                }
                Console.WriteLine();
            }
        }

        public bool PlayMove(Player player)
        {
            Console.WriteLine("Invalid input quits game.");
            Console.Write($"Player {player} enter row,column eg. 1,2 >>> ");
            string move = Console.ReadLine();
            string[] moves = move.Split(',');
            if (moves.Length != 2)
            {
                return false;
            }
            if ((!int.TryParse(moves[0], out int row)) || (!int.TryParse(moves[1], out int column)))
            {
                return false;
            }
            if (row < 1 || row > 3 || column < 1 || column > 3)
            {
                return false;
            }
            if (_board[row-1, column-1].Owner != Player.Noone)
            {
                Console.WriteLine("Alredy occupied!");
                return false;
            }
            _board[row-1, column-1] = new Square(player);
            return true;

        }

    }

}