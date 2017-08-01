// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TickTockGo
{
	[Register ("GameSetupVC")]
	partial class GameSetupVC
	{
		[Outlet]
		UIKit.UIButton easyButton { get; set; }

		[Outlet]
		UIKit.UIButton hardButton { get; set; }

		[Outlet]
		UIKit.UIButton mediumButton { get; set; }

		[Outlet]
		UIKit.UITextField playerName1 { get; set; }

		[Outlet]
		UIKit.UITextField playerName2 { get; set; }

		[Action ("Easy:")]
		partial void Easy (Foundation.NSObject sender);

		[Action ("Hard:")]
		partial void Hard (Foundation.NSObject sender);

		[Action ("Medium:")]
		partial void Medium (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (playerName1 != null) {
				playerName1.Dispose ();
				playerName1 = null;
			}

			if (playerName2 != null) {
				playerName2.Dispose ();
				playerName2 = null;
			}

			if (easyButton != null) {
				easyButton.Dispose ();
				easyButton = null;
			}

			if (mediumButton != null) {
				mediumButton.Dispose ();
				mediumButton = null;
			}

			if (hardButton != null) {
				hardButton.Dispose ();
				hardButton = null;
			}
		}
	}
}
