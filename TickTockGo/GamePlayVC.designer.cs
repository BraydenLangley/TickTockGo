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
	[Register ("GamePlayVC")]
	partial class GamePlayVC
	{
		[Outlet]
		UIKit.UIButton cell1 { get; set; }

		[Outlet]
		UIKit.UIButton cell2 { get; set; }

		[Outlet]
		UIKit.UIButton cell3 { get; set; }

		[Outlet]
		UIKit.UIButton cell4 { get; set; }

		[Outlet]
		UIKit.UIButton cell5 { get; set; }

		[Outlet]
		UIKit.UIButton cell6 { get; set; }

		[Outlet]
		UIKit.UIButton cell7 { get; set; }

		[Outlet]
		UIKit.UIButton cell8 { get; set; }

		[Outlet]
		UIKit.UIButton cell9 { get; set; }

		[Outlet]
		UIKit.UILabel currentPlayerLeft { get; set; }

		[Outlet]
		UIKit.UILabel currentPlayerRight { get; set; }

		[Outlet]
		UIKit.UILabel player1 { get; set; }

		[Outlet]
		UIKit.UILabel player2 { get; set; }

		[Outlet]
		UIKit.UILabel upperLabel { get; set; }

		[Outlet]
		UIKit.UILabel winsForPlayer1 { get; set; }

		[Outlet]
		UIKit.UILabel winsForPlayer2 { get; set; }

		[Action ("Claim:")]
		partial void Claim (Foundation.NSObject sender);

		[Action ("Reset:")]
		partial void Reset (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (cell1 != null) {
				cell1.Dispose ();
				cell1 = null;
			}

			if (cell2 != null) {
				cell2.Dispose ();
				cell2 = null;
			}

			if (cell3 != null) {
				cell3.Dispose ();
				cell3 = null;
			}

			if (cell4 != null) {
				cell4.Dispose ();
				cell4 = null;
			}

			if (cell5 != null) {
				cell5.Dispose ();
				cell5 = null;
			}

			if (cell6 != null) {
				cell6.Dispose ();
				cell6 = null;
			}

			if (cell7 != null) {
				cell7.Dispose ();
				cell7 = null;
			}

			if (cell8 != null) {
				cell8.Dispose ();
				cell8 = null;
			}

			if (cell9 != null) {
				cell9.Dispose ();
				cell9 = null;
			}

			if (upperLabel != null) {
				upperLabel.Dispose ();
				upperLabel = null;
			}

			if (player1 != null) {
				player1.Dispose ();
				player1 = null;
			}

			if (player2 != null) {
				player2.Dispose ();
				player2 = null;
			}

			if (winsForPlayer2 != null) {
				winsForPlayer2.Dispose ();
				winsForPlayer2 = null;
			}

			if (winsForPlayer1 != null) {
				winsForPlayer1.Dispose ();
				winsForPlayer1 = null;
			}

			if (currentPlayerLeft != null) {
				currentPlayerLeft.Dispose ();
				currentPlayerLeft = null;
			}

			if (currentPlayerRight != null) {
				currentPlayerRight.Dispose ();
				currentPlayerRight = null;
			}
		}
	}
}
