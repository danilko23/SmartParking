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
	[Register ("BeaconsController")]
	partial class BeaconsController
	{
		[Outlet]
		AppKit.NSButton Car1 { get; set; }

		[Outlet]
		AppKit.NSButton Car2 { get; set; }

		[Outlet]
		AppKit.NSButton Car3 { get; set; }

		[Outlet]
		AppKit.NSTextField error { get; set; }

		[Outlet]
		AppKit.NSComboBox menu { get; set; }

		[Outlet]
		AppKit.NSComboBox Name { get; set; }

		[Outlet]
		AppKit.NSBox Selection { get; set; }

		[Action ("Button1:")]
		partial void Button1 (Foundation.NSObject sender);

		[Action ("Button2:")]
		partial void Button2 (Foundation.NSObject sender);

		[Action ("Button3:")]
		partial void Button3 (Foundation.NSObject sender);

		[Action ("Cancel:")]
		partial void Cancel (Foundation.NSObject sender);

		[Action ("Delete:")]
		partial void Delete (Foundation.NSObject sender);

		[Action ("menuAction:")]
		partial void menuAction (Foundation.NSObject sender);

		[Action ("Save:")]
		partial void Save (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Car1 != null) {
				Car1.Dispose ();
				Car1 = null;
			}

			if (Car2 != null) {
				Car2.Dispose ();
				Car2 = null;
			}

			if (Car3 != null) {
				Car3.Dispose ();
				Car3 = null;
			}

			if (error != null) {
				error.Dispose ();
				error = null;
			}

			if (menu != null) {
				menu.Dispose ();
				menu = null;
			}

			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}

			if (Selection != null) {
				Selection.Dispose ();
				Selection = null;
			}
		}
	}
}
