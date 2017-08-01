using System;

using UIKit;

namespace TickTockGo
{
    public partial class GamePlayVC : UIViewController
    {
		public string Variation { get; set; }
        public string OpponentSkillLevel { get; set; }
        public string[] Players { get; set; }

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
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

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

            computerAI = new AI(_cells, grid);
        }

        partial void Claim(Foundation.NSObject sender)
        {
			UIButton cell = sender as UIButton;
			string id = cell.Tag.ToString();

			computerAI.Set(Int32.Parse(id), false);
			computerAI.AIturn(grid, 0, true, true);
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

            computerAI = new AI(_cells, grid);
        }
    }
}

