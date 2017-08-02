using System;
using UIKit;
namespace TickTockGo
{
    public class AI
    {
        public AI(int[,] winMatrix, int[] grid, GamePlayVC gamePlayVC)
        {
            _winMatrix = winMatrix;
            _grid = grid;
            _gamePlayVC = gamePlayVC;
        }

        GamePlayVC _gamePlayVC;

        int[] _grid;
        bool _gameIsRunning = true;
        int[,] _winMatrix;

        /// <summary>
        /// Calculates the move using the MiniMax Algorithm.
        /// </summary>
        /// <returns>The move.</returns>
        /// <param name="board">Board.</param>
        /// <param name="depth">Depth.</param>
        /// <param name="player">Player.</param>
        /// <param name="turn">If set to <c>true</c> turn.</param>
		public int CalculateMove(int[] board, int depth, int player, bool turn)
		{
			if (_gamePlayVC.CheckWin(board, -player))
			{
				return -10 + depth;
			}

			if (_gamePlayVC.CheckFull(board))
			{
				return 0;
			}

			var max = -50;
			var index = 0;

			for (var x = 0; x < 9; x++)
			{
				if (board[x] == 0)
				{
					int[] newBoard = new int[9];
					board.CopyTo(newBoard, 0);

					newBoard[x] = player;

					var moveValue = -CalculateMove(newBoard, depth + 1, -player, false);

					if (moveValue > max)
					{
						max = moveValue;
						index = x;
					}
				}
			}

			if (turn)
			{
                //Set(index, player);
                return index;
			}

			return max;
		}
    }
}
