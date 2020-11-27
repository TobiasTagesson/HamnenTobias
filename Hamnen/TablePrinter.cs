using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hamnen
{
    public class TablePrinter
    {
        private readonly string[] titles;
        private readonly List<int> lengths;
        private readonly List<string[]> rows = new List<string[]>();

        public TablePrinter(params string[] titles)
        {
            this.titles = titles;
            lengths = titles.Select(t => t.Length).ToList();
        }

        public void AddRow(params object[] row)
        {
            if (row.Length != titles.Length)
            {
                throw new System.Exception($"Added row length [{row.Length}] is not equal to title row length [{titles.Length}]");
            }
            rows.Add(row.Select(o => o.ToString()).ToArray());
            for (int i = 0; i < titles.Length; i++)
            {
                if (rows.Last()[i].Length > lengths[i])
                {
                    lengths[i] = rows.Last()[i].Length;
                }
            }
        }

        public void Print()
        {
            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < titles.Length; i++)
            {
                line += "| " + titles[i].PadRight(lengths[i]) + ' ';
            }
            System.Console.WriteLine(line + "|");

            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            foreach (var row in rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(lengths[i]) + ' ';  // numbers are padded to the left
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(lengths[i]) + ' ';
                    }
                }
                System.Console.WriteLine(line + "|");
            }

            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");
        }

        public static void PrintTable()
        {
            Boat[] parkedBoats = Harbour.slots;

            var t = new TablePrinter("Plats", "Båttyp", "Id", "Högsta Hastighet", "Vikt");
            int index = 1;

            // Print to console with tableprinter class
            foreach (var boat in parkedBoats)
            {
                if (boat != null)
                {
                    t.AddRow(index, boat.boatType, boat.Id, boat.MaxSpeed + " knop", boat.Weight + " kg");
                }
                else
                {
                    t.AddRow(index, "", "", "", "");
                }
                index++;
            }

            t.Print();
            PrintSlotInfo();
            
        }
        public static void PrintSlotInfo()
        {
            Harbour dailyHarbour = new Harbour();

            dailyHarbour.ShowNumberOfAvailableSlots();
            Harbour.PrintRejectedBoats();

        }
        public static void PrintUI()
        {
            int numberOfDaysToShow = 30;
            Harbour dailyHarbour = new Harbour();
        
                for (int i = 0; i < numberOfDaysToShow; i++)
                {
                    dailyHarbour.DeleteDepartingBoats();
                    dailyHarbour.DailyBoatArrival();
                    PrintTable();
                    Console.ReadLine();
                    dailyHarbour.CountDownDaysInHarbour();
                    Console.Clear();
                }
        }
    }
}
