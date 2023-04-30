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
	[Register ("ParkingViewController")]
	partial class ParkingViewController
	{
		[Outlet]
		AppKit.NSTextField nBeacons { get; set; }

		[Outlet]
		AppKit.NSBox ParkingArea { get; set; }

		[Outlet]
		AppKit.NSTextField SpotsOccupied { get; set; }

		[Outlet]
		AppKit.NSTextField TotalSpots { get; set; }

		[Action ("CarsSettings:")]
		partial void CarsSettings (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nBeacons != null) {
				nBeacons.Dispose ();
				nBeacons = null;
			}

			if (ParkingArea != null) {
				ParkingArea.Dispose ();
				ParkingArea = null;
			}

			if (SpotsOccupied != null) {
				SpotsOccupied.Dispose ();
				SpotsOccupied = null;
			}

			if (TotalSpots != null) {
				TotalSpots.Dispose ();
				TotalSpots = null;
			}
		}
	}
}
