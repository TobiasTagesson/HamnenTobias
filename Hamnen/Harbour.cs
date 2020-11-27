using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hamnen
{
    public class Harbour
    {
        public static Boat[] slots = new Boat[25];
        public static List<Boat> rejectedBoatList = new List<Boat>();

        public Boat FindSlotForBoat(Boat boat)
        {

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null)
                {
                    bool willBoatFit = WillBoatFitInSlot(i, boat.NumberOfSlots);

                    if(willBoatFit)
                    {
                        ParkBoat(i, boat);
                        return null;
                    }
                }
            }
            return boat;
        }

        private void ParkBoat(int slotStartIndex, Boat boat)
        {
            for (int i = 0; i < boat.NumberOfSlots; i++)
            {
                slots[slotStartIndex + i] = boat;
            }
        }

        private bool WillBoatFitInSlot(int slotStartIndex, int numberOfSlots)
        {
            if(slotStartIndex + numberOfSlots > slots.Length)
            {
                return false;
            }
            int availableSlots = 0;

            for (int i = slotStartIndex; i < slotStartIndex + numberOfSlots; i++)
            {
                if(slots[i] != null)
                {
                    return false;
                }
                availableSlots++;
            }
            if(availableSlots == numberOfSlots)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DailyBoatArrival()
        {
            List<Boat> dailyBoatList = new List<Boat>();
            dailyBoatList = CreateBoat.CreateListOfBoats();

            foreach (var dailyBoat in dailyBoatList)
            {
                IncomingBoat(dailyBoat);
            }
        } 

        public void IncomingBoat(Boat boat)
        {
            var rejectedBoat = FindSlotForBoat(boat);

            if(rejectedBoat != null)
            {
                rejectedBoatList.Add(rejectedBoat);
            }
        }

        public void CountDownDaysInHarbour()
        
        {
            var boatsInHarbour = GetBoatsInHarbour();
            var filledSlots = boatsInHarbour.Distinct().ToList();

            for (int i = 0; i < filledSlots.Count; i++)
            {
                if(filledSlots[i] != null)
                {
                    filledSlots[i].NumberOfDaysInHarbour--;
                }
            }
        }
        public Boat[] GetBoatsInHarbour()
        {
            return slots;
        }
        public void DeleteDepartingBoats()
        {
            var boatsInHarbour = GetBoatsInHarbour();
            for (int i = 0; i < boatsInHarbour.Length; i++)
            {
                if(boatsInHarbour[i] != null)
                {
                    if(boatsInHarbour[i].NumberOfDaysInHarbour < 1)
                    {
                        boatsInHarbour[i] = null;
                    }
                }
            }
        }
        public void ShowNumberOfAvailableSlots()
        {
            int numberOfAvailableSlots = 0;
            foreach (var slot in slots)
            {
                if(slot == null)
                {
                    numberOfAvailableSlots++;
                }
            }
            Console.WriteLine("Antal lediga platser: " + numberOfAvailableSlots);
        }

        public static void PrintRejectedBoats()
        {
            int rejectedBoats = 0;
            foreach (var item in rejectedBoatList)
            {
                rejectedBoats++;
            }
                Console.WriteLine("Antal avvisade båtar: " + rejectedBoats);
        }
 
    }

}
