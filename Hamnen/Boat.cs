using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    public class Boat
    {
        public string boatType { get; set; }
        public int NumberOfSlots { get; set; }
        public string Id { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        public int NumberOfDaysInHarbour { get; set; }
    }

    public class MotorBoat : Boat
    {
        public MotorBoat()
        {
            boatType = "Motorbåt";
        }
        public int HorsePower { get; set; }
    }
    public class SailBoat : Boat
    {
        public SailBoat()
        {
            boatType = "Segelbåt";
        }
        public int BoatLengthInFeet { get; set; }
    }
    public class CargoShip : Boat
    {
        public CargoShip()
        {
            boatType = "Lastfartyg";
        }
        public int NumberOfContainers { get; set; }
    }
}
