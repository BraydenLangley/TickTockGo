using System;

using UIKit;

namespace TickTockGo
{
    public partial class VariationVC : UIViewController
    {
        public int NumberOfPlayers { get; set; }
        string[] _variations;

		protected VariationVC(IntPtr handle) : base(handle)
        {
			// Note: this .ctor should not contain any initialization logic.
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            _variations = new string[] { "Normal", "Fading Moves", "Rotating Platform", "Bracket Breakdown"};
        }

        partial void NextView(Foundation.NSObject sender)
        {
            UIStoryboard mainStoryboard = UIStoryboard.FromName("Main", null);
            GameSetupVC gsVC;

            if (NumberOfPlayers == 1)
            {
			    gsVC = mainStoryboard.InstantiateViewController("gameSetup1") as GameSetupVC;
			}
            else
            {
                gsVC = mainStoryboard.InstantiateViewController("gameSetup2") as GameSetupVC;
            }

            UIButton choosenButton = sender as UIButton;

            gsVC.NumberOfPlayers = NumberOfPlayers;
            gsVC.Variation = _variations[choosenButton.Tag];

            this.NavigationController.PushViewController(gsVC, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

