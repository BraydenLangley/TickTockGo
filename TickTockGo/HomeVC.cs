using System;
using System.Threading;
using UIKit;

namespace TickTockGo
{
    public partial class HomeVC : UIViewController
    {
        protected HomeVC(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var dv = segue.DestinationViewController as GameSetupVC;

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
    }
}
