using System;
using System.Collections.Generic;
using UIKit;

namespace TickTockGo
{
    public partial class GamePlayVC : UIViewController
    {
		public string Variation { get; set; }
        public string OpponentSkillLevel { get; set; }
        public List<string> Players { get; set; }

        public bool GameOver { get; set; }
        public bool WinningPlayer { get; set; }
        int playerScore = 0;
        int AIScore = 0;

		UIButton[] _cells;
		AI computerAI;

		int[] grid =
		{    0,0,0,
			 0,0,0,
			 0,0,0
		};

		protected GamePlayVC(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            Players = new List<string>();
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            if (Players.Count < 2)
            {
                Players.Add("Computer");
            }

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

            computerAI = new AI(_cells, grid, this);
        }

        partial void Claim(Foundation.NSObject sender)
        {
			UIButton cell = sender as UIButton;
			string id = cell.Tag.ToString();

			computerAI.Set(Int32.Parse(id), false);
			computerAI.AIturn(grid, 0, true, true);

            if (GameOver == true)
            {
                if (WinningPlayer == true)
                {
                    upperLabel.Text = "The computer has conquered!";
                    AIScore += 1;
                    winsForPlayer2.Text = AIScore.ToString();
                }
                if (WinningPlayer == false)
                {
                    upperLabel.Text = "You won!";
                    playerScore += 1;
                    winsForPlayer1.Text = playerScore.ToString();
                }
            }
        }

        partial void Reset(Foundation.NSObject sender)
        {
            grid = new int[]
            {    0,0,0,
                 0,0,0,
                 0,0,0
            };

            for (var x = 0; x < _cells.Length; x++)
            {
                _cells[x].SetImage(UIImage.FromBundle(""), UIControlState.Normal);
            }

            computerAI = new AI(_cells, grid, this);
            GameOver = false;

            //winsForPlayer1.Text = "0";
            //winsForPlayer2.Text = "0";

            upperLabel.Text = "Ready to begin?";
        }
    }
}

