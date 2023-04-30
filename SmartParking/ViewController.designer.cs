// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SmartParking
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField LoginNameEntry { get; set; }

		[Outlet]
		AppKit.NSTextField LoginText { get; set; }

		[Outlet]
		AppKit.NSView LoginView { get; set; }

		[Outlet]
		AppKit.NSTextField PaswordEntry { get; set; }

		[Outlet]
		AppKit.NSTextField WrongEntry { get; set; }

		[Action ("OnClickLoginButton:")]
		partial void OnClickLoginButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LoginNameEntry != null) {
				LoginNameEntry.Dispose ();
				LoginNameEntry = null;
			}

			if (LoginText != null) {
				LoginText.Dispose ();
				LoginText = null;
			}

			if (LoginView != null) {
				LoginView.Dispose ();
				LoginView = null;
			}

			if (PaswordEntry != null) {
				PaswordEntry.Dispose ();
				PaswordEntry = null;
			}

			if (WrongEntry != null) {
				WrongEntry.Dispose ();
				WrongEntry = null;
			}
		}
	}
}
