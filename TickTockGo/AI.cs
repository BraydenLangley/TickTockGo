using System;
using UIKit;
namespace TickTockGo
{
    public class AI
    {
        public AI(UIButton[] cells, int[] grid, GamePlayVC gamePlayVC)
        {
            _cells = cells;
            _grid = grid;
            _gamePlayVC = gamePlayVC;
        }

        GamePlayVC _gamePlayVC;

        UIButton[] _cells;
        int[] _grid;
		bool game = true;

		bool Human = false;
		bool Computer = true;
		const int HumanVal = -1;
		const int ComputerVal = 1;

        bool currentPlayer = false; //?

		int[,] winMatrix =
		{
			{0, 1, 2},
			{3, 4, 5},
			{6, 7, 8},
			{0, 3, 6},
			{1, 4, 7},
			{2, 5, 8},
			{0, 4, 8},
			{2, 4, 6},
		};

		public void Claim()
		{
			// Don't think we need this without a GUI.
		}

		private int GetPlayerId(bool player)
		{
			if (player == Human)
			{
				return -1;
			}
			else
			{
				return 1;
			}
		}

        public void Set(int index, bool player)
		{
			if (!game)
				return;

			if (_grid[index] == 0)
			{
                string imageName;

                if (player == Computer)
                {
                    imageName = "X";
                }
                else
                {
                    imageName = "O";
                }

				// Confirm this returns the right number.
				_grid[index] = GetPlayerId(player);

                _cells[index].SetImage(UIImage.FromBundle($"{imageName}"), UIControlState.Normal);

				currentPlayer = !currentPlayer;
				//AIturn(grid, 0, currentPlayer, false);

				if (CheckWin(_grid, player) || CheckFull(_grid))
				{
					game = false;
                    _gamePlayVC.GameOver = true;
                    _gamePlayVC.WinningPlayer = player;
				}
			}
		}

		/// <summary>
		/// Checks to see if the move is a win?
		/// </summary>
		/// <returns><c>true</c>, if win wis true, <c>false</c> otherwise.</returns>
		/// <param name="board">Grid.</param>
		/// <param name="player">Player.</param>
        private bool CheckWin(int[] board, bool player)
		{
			var value = GetPlayerId(player);

			for (var x = 0; x < 8; x++)
			{
				var win = true;

				for (var y = 0; y < 3; y++)
				{
					if (board[winMatrix[x, y]] != value)
					{
						win = false;
						break;
					}
				}

				if (win)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Checks to see if the board is full.
		/// </summary>
		/// <returns><c>true</c>, if full was checked, <c>false</c> otherwise.</returns>
		/// <param name="board">Board.</param>
		private bool CheckFull(int[] board)
		{
			for (var x = 0; x < 9; x++)
			{
				if (board[x] == 0)
				{
					return false;
				}
			}

			return true;
		}

		public int AIturn(int[] board, int depth, bool player, bool turn)
		{
			if (CheckWin(board, !player))
			{
				return -10 + depth;
			}

			if (CheckFull(board))
			{
				return 0;
			}

			var value = GetPlayerId(player);
			var max = -50;
			var index = 0;

			for (var x = 0; x < 9; x++)
			{
				if (board[x] == 0)
				{
					int[] newBoard = new int[9];
					board.CopyTo(newBoard, 0);

					newBoard[x] = value;

					var moveValue = -AIturn(newBoard, depth + 1, !player, false);

					if (moveValue > max)
					{
						max = moveValue;
						index = x;
					}
				}
			}

			if (turn)
			{
                Set(index, player);
			}

			return max;
		}
    }
}
