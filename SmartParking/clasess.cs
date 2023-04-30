using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using AppKit;
using Firebase.Database;
using ThreadNetwork;
using static Darwin.Message;

namespace SmartParking
{
    public class Beacon
    {
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double D3 { get; set; }
        public double D4 { get; set; }
        public long Id { get; set; }
        public long Time { get; set; }
        public Position position { get; set; }
        public Car car { get; set; }

        Beacon()
        {
            position = new Position();
            car = new Car();
        }
    }



    public class Beacons
    {
        public int total { get; set; }
        public Beacon[] data { get; set; }
    }
  
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Slot
    {
        public int ID { get; set; }
        public Position[] position { get; set; }
        public NSImageView display;
    }

    public class ParkingMap
    {
        public int total { get; set; }
        public Slot[] data { get; set; }
        public int slotHeight;
        public int slotWidth;
    }

    public class Sensor
    {
        public Position position { get; set; }
    }

    public class Sensors
    {
        public int total { get; set; }
        public Sensor[] data { get; set; }
    }

    public class Car
    {
        public NSImageView display;
        public string type = "Car1";

    }

    public class CarData
    {
        public string name { get; set; }
        public string ID { get; set; }
        public string type { get; set; }
    }

    public class Parking
    {
        public static List<long> beaconsList = new List<long>();

        public int xOffset; //to draw car in the center of the lot
        public int yOffset; //to draw car in the center of the lot
        public int spotsOcupied;
        public nfloat height;
        public nfloat width;
        public ParkingMap map { get; set; }
        public Beacons beacons { get; set; }
        public Sensors sensors { get; set; }

        public void update(int n, bool isFirst)
        {
            getBeaconPosition(n);

            int SlotId = getSlotId(n);
            if (SlotId < 0)
            {
                beacons.data[n].car.display.Hidden = true;
                spotsOcupied--;
            }
            else
            {
                nfloat x = map.data[SlotId].position[3].x * 5 + xOffset;
                nfloat y = height - map.data[SlotId].position[3].y * 5 + yOffset;

                beacons.data[n].car.display.Hidden = false;
                beacons.data[n].car.display.SetFrameOrigin(new CoreGraphics.CGPoint(x, y));
                                                               
                if (!isFirst)
                    spotsOcupied++;
            }
        }
            
        int getSlotId(int n)//get index of beacon
        {
            foreach (var slot in map.data)
            {
                    if (isInSlot(beacons.data[n].position, slot.position[0], slot.position[2]))
                    {
                        return slot.ID;
                    }
            }

            return -1;
        }

        bool isInSlot(Position beacon, Position topLeft, Position bottomRight)
        {
            // to find the 70 % of the parking slot
            var yOff = (bottomRight.y - topLeft.y) * 0.082; 
            var xOff = (bottomRight.x - topLeft.x) * 0.082;

            if (beacon.x > topLeft.x + xOff && // left boundry
                beacon.x < bottomRight.x - xOff && // right boundry
                beacon.y > topLeft.y + yOff && // top boundry
                beacon.y < bottomRight.y - yOff) // bottom boundry 
                return true;
            else
                return false;
        }

        void getBeaconPosition(int n) //takes index of the beacon
        {
            //get distances
            double[] Ds = 
            {
               beacons.data[n].D1,
               beacons.data[n].D2,
               beacons.data[n].D3,
               beacons.data[n].D4
            };

            int[] indexes = {0, 1, 2 };

            
            //get indexes of 3 closest sensors
            int cur = 3;
            for (int i = 0; i < 3; i++)
            {
                if (Ds[cur] < Ds[i])
                {
                    int tmp = indexes[i];
                    indexes[i] = cur;
                    cur = tmp;
                }
            }


            //triangulation
            triangulation(n, indexes[0], indexes[1], indexes[2], Ds);
        }

        void triangulation(int n, int i1, int i2, int i3, double[] Ds)
        { 
            int x1 = sensors.data[i1].position.x;
            int y1 = sensors.data[i1].position.y;
            double r1 = Ds[i1];
            int x2 = sensors.data[i2].position.x;
            int y2 = sensors.data[i2].position.y;
            double r2 = Ds[i2];
            int x3 = sensors.data[i3].position.x;
            int y3 = sensors.data[i3].position.y;
            double r3 = Ds[i3];

            var A = 2 * x2 - 2 * x1;
            var B = 2 * y2 - 2 * y1;
            var C = r1 * r1 - r2 * r2 - x1 * x1 + x2 * x2 - y1 * y1 + y2 * y2;
            var D = 2 * x3 - 2 * x2;
            var E = 2 * y3 - 2 * 2;
            var F = r2 * r2 - r3 * r3 - x2 * x2 + x3 * x3 - y2 * y2 + y3 * y3;
            beacons.data[n].position.x = (int) ((C * E - F * B) / (E * A - B * D));
            beacons.data[n].position.y = (int) ((C * D - A * F) / (B * D - A * E));
        }
    }
}
