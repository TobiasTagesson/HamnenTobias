using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hamnen
{
    public class CreateBoat
    {
        const int numberOfDailyBoats = 5;
        public static List<Boat> CreateListOfBoats()
        {
            List<Boat> dailyBoatList = new List<Boat>();
            for (int i = 0; i < numberOfDailyBoats; i++)
            {
                var dailyBoat = GenerateBoatType();
                dailyBoatList.Add(dailyBoat);

            }
            return dailyBoatList;
        }

        private static Boat GenerateBoatType()
        {
            Boat boat = new Boat();
            Random r = new Random();
            int boatTypeNumber = r.Next(3);
            if(boatTypeNumber == 0)
            {
                 boat = CreateMotorBoat();
            }
            else if(boatTypeNumber == 1)
            {
                boat = CreateSailBoat();
            }
            else
            {
                boat = CreateCargoShip();
            }
            return boat;
        }

        public static MotorBoat CreateMotorBoat()
        {
            MotorBoat mb = new MotorBoat();
            
            mb.Id = GenerateId("M");
            mb.Weight = GenerateWeight(200, 3000);
            mb.MaxSpeed = GenerateMaxSpeed(60);
            mb.HorsePower = GenerateHorsePower(10, 1000);
            mb.NumberOfDaysInHarbour = 3;
            mb.NumberOfSlots = 1;

            return mb;
        }

        public static SailBoat CreateSailBoat()
        {
            SailBoat sb = new SailBoat();

            sb.Id = GenerateId("S");
            sb.Weight = GenerateWeight(800, 6000);
            sb.MaxSpeed = GenerateMaxSpeed(12);
            sb.BoatLengthInFeet = GenerateLength(10, 60);
            sb.NumberOfDaysInHarbour = 4;
            sb.NumberOfSlots = 2;

            return sb;
        }

        public static CargoShip CreateCargoShip()
        {
            CargoShip cg = new CargoShip();

            cg.Id = GenerateId("L");
            cg.Weight = GenerateWeight(3000, 20000);
            cg.MaxSpeed = GenerateMaxSpeed(20);
            cg.NumberOfContainers = GenerateNumberOfContainers(500);
            cg.NumberOfDaysInHarbour = 6;
            cg.NumberOfSlots = 4;

            return cg;
        }

        private static int GenerateNumberOfContainers(int maxNumberOfContainers)
        {
            Random r = new Random();
            int numberOfContainers = r.Next(0, maxNumberOfContainers + 1);
            return numberOfContainers;
        }

        private static int GenerateLength(int minLength, int maxLength)
        {
            Random r = new Random();
            int length = r.Next(minLength, maxLength + 1);
            return length;
        }

        private static int GenerateHorsePower(int minHP, int maxHp)
        {
            Random r = new Random();
            int hp = r.Next(minHP, maxHp + 1);
            return hp;
        }

        private static int GenerateMaxSpeed(int maxSpeed)
        {
            Random r = new Random();
            int speed = r.Next(0, maxSpeed + 1);
            return speed;
        }

        private static int GenerateWeight(int minWeight, int maxWeight)
        {
            Random r = new Random();
            int weight = r.Next(minWeight, maxWeight + 1);
            return weight;
        }

       // private static Random randomLetter = new Random();
        private static string GenerateId(string prefix)
        {
            Random r = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var IdNo = (Enumerable.Repeat(chars, 3).Select(s => s[r.Next(s.Length)]).ToArray());
            string idSuffix = new string(IdNo);
            return prefix + "-" + idSuffix;
        }
    }
}
    
