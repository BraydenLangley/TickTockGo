using System;
using System.Collections.Generic;
using UIKit;
using System.Threading;

namespace TickTockGo
{
    public partial class GamePlayVC : UIViewController
    {
		public string Variation { get; set; }
        public string OpponentSkillLevel { get; set; }
        public List<string> Players { get; set; }

        public bool GameOver { get; set; }
        public string WinningPlayer { get; set; }
        int player1Score = 0;
        int player2Score = 0;

		UIButton[] _cells;
		AI computerAI;
        Random randomNumberGenerator;

		Dictionary<string, int> _players = new Dictionary<string, int>();

        int[] _grid =
		{    0,0,0,
			 0,0,0,
			 0,0,0
		};

        public int[,] _winMatrix =
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

		string _currentPlayer; //?
        bool humanVSComputer;

		protected GamePlayVC(IntPtr handle) : base(handle)
        {
            // Should initialization logic be in this constructor?

            Players = new List<string>();
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            if (Players.Count < 2)
            {
                Players.Add("Computer");
                computerAI = new AI(_winMatrix, _grid, this);
                humanVSComputer = true;
			}
            else
            {
                humanVSComputer = false;
            }

			_players.Add(Players[0], -1);
			_players.Add(Players[1], 1);

            player1.Text = Players[0];
            player2.Text = Players[1];

			_cells = new UIButton[] {
				cell1,
				cell2,
				cell3,
				cell4,
				cell5,
				cell6,
				cell7,
				cell8,
				cell9
			};

            _currentPlayer = Players[0];
            randomNumberGenerator = new Random();
            this.NavigationItem.LeftBarButtonItem = new UIBarButtonItem("End Game", UIBarButtonItemStyle.Plain, (sender, e) => 
            {
				this.NavigationController.PopToRootViewController(true);

			});
        }

        //Refactor.
        /// <summary>
        /// Claim the specified cell.
        /// </summary>
        /// <returns>The claim.</returns>
        /// <param name="sender">Sender.</param>
        partial void Claim(Foundation.NSObject sender)
        {
            UIButton cell = sender as UIButton;
            string id = cell.Tag.ToString();

            if (humanVSComputer)
            {
                // Is this necessary?
				if (_currentPlayer == Players[0])
				{
					MakeTheMove(Int32.Parse(id), _players[Players[0]]);

                    if (!GameOver)
                    {
						new Thread(new ThreadStart(() =>
					{
                            Thread.Sleep(randomNumberGenerator.Next(500, 1600));

						InvokeOnMainThread(() =>
						{
                                int moveToPlay = computerAI.CalculateMove(_grid, randomNumberGenerator.Next(0, 8), _players[Players[1]], true);
							MakeTheMove(moveToPlay, _players[Players[1]]);
						});
					})).Start();
                    }
                }
            }
            else
            {
				if (_currentPlayer == Players[0])
				{
					MakeTheMove(Int32.Parse(id), _players[Players[0]]);
				}
				else
				{
					MakeTheMove(Int32.Parse(id), _players[Players[1]]);
				} 
            }
		}

        // TODO: REFACTOR DUPLICATED CODE!!
        void MakeTheMove(int index, int playerValue)
        {
			if (_grid[index] == 0)
			{
				string imageName;

                if (playerValue == _players[Players[0]])
				{
					imageName = "O";
				}
				else
				{
					imageName = "X";
				}

                _grid[index] = playerValue;

				_cells[index].SetImage(UIImage.FromBundle($"{imageName}"), UIControlState.Normal);
				_cells[index].UserInteractionEnabled = false;

                if (CheckWin(_grid, playerValue))
				{
					GameOver = true;

					if (playerValue == _players[Players[0]])
					{
						WinningPlayer = Players[0];
						player1Score += 1;
						winsForPlayer1.Text = player1Score.ToString();
					}
					else
					{
						WinningPlayer = Players[1];
						player2Score += 1;
						winsForPlayer2.Text = player2Score.ToString();
 					}

                    upperLabel.Text = "Player " + WinningPlayer + " has won!";
				}

				// Refactor duplication.
				if (CheckFull(_grid) && !CheckWin(_grid, playerValue))
				{
					GameOver = true;
					WinningPlayer = "Tie";
                    upperLabel.Text = "It was a Tie!";
				}

				// Switch the current player.
                // TODO: Refactor this code.
                if (_currentPlayer == Players[0] && !GameOver)
                {
                    _currentPlayer = Players[1];
                    currentPlayerLeft.Hidden = true;
                    currentPlayerRight.Hidden = false;

                    return;
                }
                if (_currentPlayer == Players[1] && !GameOver)
                {
                    _currentPlayer = Players[0];
                    currentPlayerRight.Hidden = true;
                    currentPlayerLeft.Hidden = false;
                }
			}
        }

		/// <summary>
		/// Checks to see if the move is a win?
		/// </summary>
		/// <returns><c>true</c>, if win wis true, <c>false</c> otherwise.</returns>
		/// <param name="board">Grid.</param>
		/// <param name="player">Player.</param>
		public bool CheckWin(int[] board, int playerValue)
        {
			for (var x = 0; x < 8; x++)
			{
				var win = true;

				for (var y = 0; y < 3; y++)
				{
					if (board[_winMatrix[x, y]] != playerValue)
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
		public bool CheckFull(int[] board)
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

        /// <summary>
        /// Enables the or disable claimability.
        /// </summary>
        void EnableOrDisableClaimability(bool value)
        {
			for (var x = 0; x < _cells.Length; x++)
			{
                _cells[x].UserInteractionEnabled = value;
			}
        }

        /// <summary>
        /// Reset the specified sender.
        /// </summary>
        /// <returns>The reset.</returns>
        /// <param name="sender">Sender.</param>
        partial void Reset(Foundation.NSObject sender)
        {
            _grid = new int[]
            {    0,0,0,
                 0,0,0,
                 0,0,0
            };

            for (var x = 0; x < _cells.Length; x++)
            {
                _cells[x].SetImage(UIImage.FromBundle(""), UIControlState.Normal);
            }

            computerAI = new AI(_winMatrix, _grid, this); //Even for PvP?
            GameOver = false;

			//winsForPlayer1.Text = "0";
			//winsForPlayer2.Text = "0";

			if (humanVSComputer)
			{
				_currentPlayer = Players[0];
				currentPlayerRight.Hidden = true;
				currentPlayerLeft.Hidden = false;
			}

            upperLabel.Text = "Ready to begin?";

            EnableOrDisableClaimability(true);
        }
    }
}

