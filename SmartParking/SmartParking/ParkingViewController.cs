// This file has been autogenerated from a class added in the UI designer.

using System;

using Firebase.Database;
using Firebase.Database.Query;

using Foundation;
using AppKit;
using System.Threading.Tasks;
using CoreGraphics;
using System.IO;
using System.Runtime.InteropServices;

namespace SmartParking
{
	public partial class ParkingViewController : NSViewController
	{

        public Parking parking = new Parking();
        public FirebaseClient client = new FirebaseClient("https://heymotocarro-1a1d4.firebaseio.com/");

        public ParkingViewController (IntPtr handle) : base (handle)
		{
        }

        public override NSObject RepresentedObject
        {


            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Initialize();
        }

        private async void Initialize()
        {
            var task1 = getBeaconDataAsync();
            var task2 = getParkingMapAsync();
            var task3 = getSensorsAsync();


            parking.beacons = await task1;
            parking.map = await task2;
            parking.sensors = await task3;
            parking.spotsOcupied = parking.beacons.total;
            
            //assign slot IDs and get map dimmensions
            int height = 0, width = 0;
            for (int i = 0; i < parking.map.total; i++)
            {
                parking.map.data[i].ID = i;

                if (parking.map.data[i].position[2].x > width)
                    width = parking.map.data[i].position[2].x;

                if (parking.map.data[i].position[2].y > height)
                    height = parking.map.data[i].position[2].y;
            }

            parking.height = height * 5; //multiply by 5 to make it bigger on the screen
            parking.width = width * 5 + 15; //+15 to make parking look nice

            parking.map.slotHeight = parking.map.data[0].position[3].y - parking.map.data[0].position[0].y;
            parking.map.slotWidth = parking.map.data[0].position[1].x - parking.map.data[0].position[0].x;

            parking.xOffset = (int)parking.map.slotWidth / 2;
            parking.yOffset = (int)parking.map.slotHeight / 2;

            displayParkingSpots();

            getCarData();

            Parking.beaconsList.Clear();

            //initialize cars
            for (int i = 0; i < parking.beacons.total; i++)
            {
                initCars(i);
                parking.update(i, true);
                Parking.beaconsList.Add(parking.beacons.data[i].Id);
            }

            updateData();
            onChildChanged();
        }

        void getCarData()
        {
            var lines = File.ReadAllLines(@"CarData.txt");

            foreach(var line in lines)
            {
                if (line == "")
                    continue;

                string[] data = line.Split(',');

                var ID = long.Parse(data[1]);
                var type = data[2];

                foreach (var beacon in parking.beacons.data)
                {
                    if(beacon.Id == ID)
                    {
                        beacon.car.type = type;
                    }
                }
            }   
        }

        void displayParkingSpots()
        {
            //set the box around the parking
            ParkingArea.Frame = new CGRect(ParkingArea.Frame.Location, new CGSize(parking.width, parking.height));

            // in cocoa app point (0,0) is in the left bottom corner
            foreach(var slot in parking.map.data)
            {
                slot.display = new NSImageView(new CGRect(slot.position[3].x * 5, parking.height - slot.position[3].y * 5, parking.map.slotWidth * 5 + 8, parking.map.slotHeight * 5));

                if (slot.position[3].y * 5 < parking.height/2)
                    slot.display.Image = NSImage.ImageNamed("ParkingSlot");
                else
                    slot.display.Image = NSImage.ImageNamed("ParkingSlotRotated");

                slot.display.ImageScaling = NSImageScale.AxesIndependently;
                ParkingArea.AddSubview(slot.display);
            }

        }

        void initCars(int n)
        {
            parking.beacons.data[n].car.display = new NSImageView(new CGRect(0, 0, parking.map.slotWidth * 4, parking.map.slotHeight * 4));
            parking.beacons.data[n].car.display.Image = NSImage.ImageNamed(parking.beacons.data[n].car.type);
            ParkingArea.AddSubview(parking.beacons.data[n].car.display);
        }

        void updateData()
        {
            TotalSpots.StringValue = parking.map.total.ToString();
            nBeacons.StringValue = parking.beacons.total.ToString();
            SpotsOccupied.StringValue = parking.spotsOcupied.ToString();
        }

        public async Task<Beacons> getBeaconDataAsync()
        {
            //******************** Get initial list of beacons ***********************//
          
            Beacons beacons = await client
               .Child("Beacons/")
               .OnceSingleAsync<Beacons>();

            Console.WriteLine($"beacon total: {beacons.total}]");
            //
            Console.WriteLine("Function is working");

            return beacons;
        }

        private async Task<ParkingMap> getParkingMapAsync() // grabs population from database 
        {
                ParkingMap parkingMap = await client
               .Child("ParkingMap/")
               .OnceSingleAsync<ParkingMap>();
                                  
            Console.WriteLine($"Parking Map total: {parkingMap}]");
            
            return parkingMap;
        }

        private async Task<Sensors> getSensorsAsync() // grabs population from database 
        {
                Sensors sensors = await client
               .Child("Sensors/")//Prospect list
               .OnceSingleAsync<Sensors>();
            
            Console.WriteLine($"Sensors: {sensors.total}]");

            return sensors;
        }

        private void onChildChanged() // Waits for data base to start with variable
        {

            var child = client.Child("Beacons/data");
            var observable = child.AsObservable<Beacon>();
            var subscription = observable
                .Subscribe(x =>
                {
                    Console.WriteLine($"beacon id: {x.Object.Id}");

                    for(int i = 0; i < parking.beacons.total; i++)
                    {
                        if (parking.beacons.data[i].Id == x.Object.Id)
                        {
                            parking.beacons.data[i] = x.Object;
                            parking.update(i, false);
                            updateData();
                            break;
                        }
                    }
                    
                    Console.WriteLine("Firebase updated");
                   
                });
        }

        partial void CarsSettings(Foundation.NSObject sender)
        {
            PerformSegue("CarSettingsTransition", this);
            View.Window.Close();
        }
    }
}