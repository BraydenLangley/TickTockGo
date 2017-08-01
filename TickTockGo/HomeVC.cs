using System;
using System.Threading;
using UIKit;

namespace TickTockGo
{
    public partial class HomeVC : UIViewController
    {
        UIButton[] cells;

		int[] grid =
		{    0,0,0,
			 0,0,0,
			 0,0,0
		};

        AI computerAI;

        protected HomeVC(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var dv = segue.DestinationViewController as VariationVC;

			if (dv != null)
			{
                if (segue.Identifier == "onePlayer")
                {
                    dv.NumberOfPlayers = 1;
                }
    			if (segue.Identifier == "twoPlayer")
    			{
    				dv.NumberOfPlayers = 2;
    			}
			}
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			this.NavigationController.View.BackgroundColor = UIColor.Clear;
			this.NavigationController.NavigationBar.BackgroundColor = UIColor.Clear;
			this.NavigationController.NavigationBar.ShadowImage = new UIImage();
        }

        partial void claim(Foundation.NSObject sender)
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

            for (var x = 0; x < cells.Length; x++)
            {
                cells[x].SetImage(UIImage.FromBundle(""), UIControlState.Normal);
            }

            computerAI = new AI(cells, grid);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
