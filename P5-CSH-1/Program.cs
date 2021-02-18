using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_CSH_1 {
    struct Aufgabe {
        public string aufgabe;
        public Action method;
    }
    class Program {

        static void Main(string[] args) {
            Day.days = new List<Day>() { new Day1(), new Day3() };
            StartProg();
            Console.WriteLine("\n\n--- Ende ---");
            Console.ReadKey();
        }

        static void StartProg() {
            int auswahl;
            do {
                Console.Clear();
                Console.WriteLine("C# Programmieren 5");
                Console.WriteLine("Wähle einen Tag aus \n(0) - Ende");
                Day.outputDays();
                if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                    if (auswahl <= Day.Days.Count && auswahl > 0) {
                        Day.Days[auswahl - 1].startDay();
                    }
                } else auswahl = 1;
            } while (auswahl != 0);
        }
    }

    class Day {
        protected int dayNumber;
        public static List<Day> days;
        protected List<Aufgabe> aufgaben = new List<Aufgabe>();

        public static List<Day> Days {
            get { return days; }
        }

        public List<Aufgabe> Aufgaben {
            get { return aufgaben; }
        }

        public int DayNumber {
            get { return dayNumber; }
        }

        // Konstruktor
        public Day(int number) {
            dayNumber = number;
        }

        public void startDay() {
            int auswahl;
            do {
                Console.Write(this + " ");
                if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                    Console.WriteLine();
                    if (auswahl <= aufgaben.Count && auswahl > 0) aufgaben[auswahl - 1].method();
                } else auswahl = 1;
            } while (auswahl != 0);
        }

        public override string ToString() {
            Console.WriteLine("\n\n\nTag " + dayNumber);
            string temp = "Bitte wählen \n(0) - Zurück / Beenden\n";
            int zaehler = 1;
            foreach (Aufgabe item in aufgaben) {
                temp += "(" + zaehler + ") - " + item.aufgabe + "\n";
                zaehler++;
            }
            return temp;
        }

        public void addAufgabe(string beschreibung, Action methode) {
            Aufgabe temp;
            temp.aufgabe = beschreibung;
            temp.method = methode;
            aufgaben.Add(temp);
        }

        public static void outputDays() {
            for (int i = 0; i < Days.Count; i++) {
                Console.WriteLine("(" + (i + 1) + ")" + " - Tag " + Days[i].DayNumber);
            }
            Console.Write(" ");
        }
    }
}
