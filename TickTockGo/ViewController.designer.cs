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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton cell1Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell2Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell3Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell4Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell5Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell6Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell7Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell8Outlet { get; set; }

		[Outlet]
		UIKit.UIButton cell9Outlet { get; set; }

		[Action ("claim:")]
		partial void claim (Foundation.NSObject sender);

		[Action ("Reset:")]
		partial void Reset (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (cell1Outlet != null) {
				cell1Outlet.Dispose ();
				cell1Outlet = null;
			}

			if (cell2Outlet != null) {
				cell2Outlet.Dispose ();
				cell2Outlet = null;
			}

			if (cell3Outlet != null) {
				cell3Outlet.Dispose ();
				cell3Outlet = null;
			}

			if (cell4Outlet != null) {
				cell4Outlet.Dispose ();
				cell4Outlet = null;
			}

			if (cell5Outlet != null) {
				cell5Outlet.Dispose ();
				cell5Outlet = null;
			}

			if (cell6Outlet != null) {
				cell6Outlet.Dispose ();
				cell6Outlet = null;
			}

			if (cell7Outlet != null) {
				cell7Outlet.Dispose ();
				cell7Outlet = null;
			}

			if (cell8Outlet != null) {
				cell8Outlet.Dispose ();
				cell8Outlet = null;
			}

			if (cell9Outlet != null) {
				cell9Outlet.Dispose ();
				cell9Outlet = null;
			}
		}
	}
}
