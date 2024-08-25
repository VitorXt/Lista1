using System;

namespace JogoDaVelha
{
    class Program
    {
        static char[,] board =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };
        static char player = 'X';
        static char computer = 'O';

        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            int move;
            while (true)
            {
                PrintBoard();
                if (player == 'X')
                {
                    Console.WriteLine("Sua vez! Escolha uma posição:");
                    move = int.Parse(Console.ReadLine());
                    MakeMove(move, player);
                    if (CheckWinner(player))
                    {
                        PrintBoard();
                        Console.WriteLine("Você ganhou!");
                        break;
                    }
                    player = computer;
                }
                else
                {
                    Console.WriteLine("Vez do computador!");
                    move = CalculateBestMove();
                    MakeMove(move, computer);
                    if (CheckWinner(computer))
                    {
                        PrintBoard();
                        Console.WriteLine("Computador ganhou!");
                        break;
                    }
                    player = 'X';
                }
                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("Empate!");
                    break;
                }
            }
        }

        static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("Jogo da Velha:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-+-+-");
            }
        }

        static void MakeMove(int move, char currentPlayer)
        {
            switch (move)
            {
                case 1: board[0, 0] = currentPlayer; break;
                case 2: board[0, 1] = currentPlayer; break;
                case 3: board[0, 2] = currentPlayer; break;
                case 4: board[1, 0] = currentPlayer; break;
                case 5: board[1, 1] = currentPlayer; break;
                case 6: board[1, 2] = currentPlayer; break;
                case 7: board[2, 0] = currentPlayer; break;
                case 8: board[2, 1] = currentPlayer; break;
                case 9: board[2, 2] = currentPlayer; break;
            }
        }

        static bool CheckWinner(char currentPlayer)
        {
            return (board[0, 0] == currentPlayer && board[0, 1] == currentPlayer && board[0, 2] == currentPlayer) ||
                   (board[1, 0] == currentPlayer && board[1, 1] == currentPlayer && board[1, 2] == currentPlayer) ||
                   (board[2, 0] == currentPlayer && board[2, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                   (board[0, 0] == currentPlayer && board[1, 0] == currentPlayer && board[2, 0] == currentPlayer) ||
                   (board[0, 1] == currentPlayer && board[1, 1] == currentPlayer && board[2, 1] == currentPlayer) ||
                   (board[0, 2] == currentPlayer && board[1, 2] == currentPlayer && board[2, 2] == currentPlayer) ||
                   (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                   (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer);
        }

        static bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
                        return false;
                }
            }
            return true;
        }

        static int CalculateBestMove()
        {
            int bestScore = int.MinValue;
            int bestMove = -1;

            for (int i = 1; i <= 9; i++)
            {
                int row = (i - 1) / 3;
                int col = (i - 1) % 3;
                if (board[row, col] != 'X' && board[row, col] != 'O')
                {
                    board[row, col] = computer;
                    int score = Minimax(board, 0, false);
                    board[row, col] = (char)(i + '0');
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }

            return bestMove;
        }

        static int Minimax(char[,] board, int depth, bool isMaximizing)
        {
            if (CheckWinner(computer)) return 10 - depth;
            if (CheckWinner('X')) return depth - 10;
            if (IsBoardFull()) return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 1; i <= 9; i++)
                {
                    int row = (i - 1) / 3;
                    int col = (i - 1) % 3;
                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = computer;
                        int score = Minimax(board, depth + 1, false);
                        board[row, col] = (char)(i + '0');
                        bestScore = Math.Max(score, bestScore);
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 1; i <= 9; i++)
                {
                    int row = (i - 1) / 3;
                    int col = (i - 1) % 3;
                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = 'X';
                        int score = Minimax(board, depth + 1, true);
                        board[row, col] = (char)(i + '0');
                        bestScore = Math.Min(score, bestScore);
                    }
                }
                return bestScore;
            }
        }
    }
}
