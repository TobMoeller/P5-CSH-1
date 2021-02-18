using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_CSH_1 {
    class Day1 : Day {
        public Day1() : base(1) {
            addAufgabe("Generics: Beispiel 1", Transcript1);
            addAufgabe("Generics: Aufgabe 0", Exercise01);
            addAufgabe("Generics: Aufgabe 1", Exercise02);
            addAufgabe("Generics: Aufgabe 2", Exercise03);
        }

        /*
         *      Mitschrift Generics
         */

        public void Transcript1() {
            Console.WriteLine($"Max int (1, 5): {Max(1,5)}");
            Console.WriteLine($"Max double (1.25, 0.372): {Max(1.25, 0.372)}");
            Console.WriteLine($"Max string (asd, efg): {Max("asd", "efg")}");
        }
        public T Max<T>(T x, T y) where T : IComparable<T> {
            return x.CompareTo(y) >= 0 ? x : y;
        }

        /*
         *      Generics: Aufgabe 0
         * 
         * Schreiben Sie folgendes C# Programm
         * Eine Generische Methode Tausche, die als Parameter zwei Werte vom Typ T erhält
         * und beide Werte miteinander tauscht.
         * Testen Sie die Methode im Main mit Integer, Double und Strings.
         */

        public void Exercise01() {
            // mit Integer
            var x = 1;
            var y = 5;
            Console.WriteLine($"x: {x}, y: {y}");
            Tausche(ref x, ref y);
            Console.WriteLine("Getauscht");
            Console.WriteLine($"x: {x}, y: {y}");
            Console.WriteLine();

            // mit Double
            double a = 1.56;
            double b = 5.12;
            Console.WriteLine($"a: {a}, b: {b}");
            Tausche(ref a, ref b);
            Console.WriteLine("Getauscht");
            Console.WriteLine($"a: {a}, b: {b}");
            Console.WriteLine();

            // mit Strings
            string c = "C";
            string d = "D";
            Console.WriteLine($"c: {c}, d: {d}");
            Tausche(ref c, ref d);
            Console.WriteLine("Getauscht");
            Console.WriteLine($"c: {c}, d: {d}");
            Console.WriteLine();
        }
        public void Tausche<T>(ref T x, ref T y) {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }

        /* 
         *      Generics: Aufgabe 1
         * 
         * Schreiben Sie folgendes Programm:
         * Klasse Mitarbeiter mit: string Name, int MaNummer
         * Klasse Kunde mit: String Name, string Wohnort, string TelNummer
         * Generische Klasse Sammlung mit: 
         *          public string Bezeichnung, private List<> Liste,
         *          public Hinzufügen() und public Entfernen() 
         *          um Objekte des Types der Sammlung hinzuzufügen oder zu entfernen          
         * Im Main: zwei Mitarbeiter und zwei Kunden anlegen
         *          zwei Sammlungen (eine für Mitarbeiter, eine für Kunde)
         *          Objekte ihrer entsprechenden Sammlung hinzufügen
         *			Überlegen Sie sich eine Möglichkeit, die Daten der Sammlung ausgeben zu können
         */
        public void Exercise02() {
            Mitarbeiter mitarbeiter1 = new Mitarbeiter("Guenther", 3);
            Mitarbeiter mitarbeiter2 = new Mitarbeiter("Manfred", 8);
            Kunde kunde1 = new Kunde("Sabine", "Musterhausen", "12345");
            Kunde kunde2 = new Kunde("Ulf", "Musterstadt", "678910");
            Kunde kunde3 = new Kunde("Ralf", "Musterland", "54321");
            Sammlung<Mitarbeiter> sammlungMa = new Sammlung<Mitarbeiter>();
            Sammlung<Kunde> sammlungKd = new Sammlung<Kunde>();
            
            Console.WriteLine("Mitarbeitersammlung:");
            sammlungMa.Hinzufuegen(mitarbeiter1);
            sammlungMa.Hinzufuegen(mitarbeiter2);
            sammlungMa.Ausgabe();

            Console.WriteLine("\nKundensammlung: ");
            sammlungKd.Hinzufuegen(kunde1);
            sammlungKd.Hinzufuegen(kunde2);
            sammlungKd.Hinzufuegen(kunde3);
            sammlungKd.Ausgabe();
        }
        class Mitarbeiter {
            public string Name { get; set; }
            public int MaNummer { get; set; }
            public Mitarbeiter(string name, int maNummer) {
                Name = name;
                MaNummer = maNummer;
            }
            public override string ToString() {
                return $"Mitarbeiter {MaNummer}: {Name}";
            }
        }
        class Kunde {
            public string Name { get; set; }
            public string Wohnort { get; set; }
            public string TelNummer { get; set; }
            public Kunde(string name, string wohnort, string telNummer) {
                Name = name;
                Wohnort = wohnort;
                TelNummer = telNummer;
            }
            public override string ToString() {
                return $"Kunde mit Name: {Name}, Wohnort: {Wohnort} und Telefonnummer: {TelNummer}";
            }
        }
        class Sammlung<T> {
            public string Bezeichnung { get; set; }
            private List<T> Liste;
            public Sammlung() {
                Liste = new List<T>();
            }
            public void Hinzufuegen(T item) {
                Liste.Add(item);
            }
            public void Entfernen(T item) {
                Liste.Remove(item);
            }
            public void Ausgabe() {
                foreach (T item in Liste) {
                    Console.WriteLine(item);
                }
            }
        }


        /* 
         *      Generics: Aufgabe 2
         * 
         * Implementieren Sie eine eigene Variante von List<>
         * Es soll möglich sein, der Liste Elemente hinzuzufügen, das erste Vorkommen eines Wertes aus der Liste zu entfernen, ein Element der Liste durch Angabe des Indexes und die Länge der Liste abzufragen. Die Liste soll sich, wie ihr Vorbild, dynamisch vergrößern. 
         * Beachten Sie die vollständige Abkapselung der Felder.
         */

        public void Exercise03() {
            try {
                MyList<string> myList = new MyList<string>();
                myList.Add("test1");
                myList.Add("test2");
                myList.Add("test3");
                myList.Add("test4");
                //Console.WriteLine($"Länge: {myList.Length}");
                Console.WriteLine($"Element an der Stelle 2: {myList.ElementAt(2)}");
                myList.Ausgabe();
                myList.Remove("test3");
                //Console.WriteLine($"Länge: {myList.Length}");
                myList.Ausgabe();

                Console.WriteLine("\n\nMit double");
                MyList<int> myListDouble = new MyList<int>();
                myListDouble.Add(5);
                myListDouble.Add(3);
                myListDouble.Add(-17);
                myListDouble.Ausgabe();
                myListDouble.Remove(5);
                myListDouble.Ausgabe();

                myListDouble.Remove(3);
                myListDouble.Remove(-17);
                myListDouble.Ausgabe();
                myListDouble.Add(3000);
                myListDouble.Ausgabe();
                myListDouble.ElementAt(1);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        class MyList<T> {
            private T[] MyArray;
            public int Length { get; private set; }
            public MyList() {
                MyArray = new T[Length];
            }
            public void Add(T item) {
                Length++;
                Array.Resize(ref MyArray, Length);
                MyArray[Length - 1] = item;
            }
            public T ElementAt(int index) {
                if (index < Length && index >= 0) return MyArray[index];
                //else return default(T);
                else throw new IndexOutOfRangeException();
            }
            public void Remove(T item) {
                bool found = false;
                for (int i = 0; i < Length; i++) {
                    // Nachrücken der Folgepositionen
                    if (found == true) {
                        MyArray[i - 1] = MyArray[i];
                    }
                    // Suche und Löschen des ersten item-Vorkommnisses
                    if (MyArray[i].Equals(item) && found == false) {
                        found = true;
                        MyArray[i] = default(T);
                    }
                }
                // Arraygröße anpassen
                if (found == true) {
                    Length--;
                    Array.Resize(ref MyArray, Length);
                }
            }
            public void Ausgabe() {
                Console.WriteLine("Länge: " + Length);
                for (int i = 0; i < Length; i++) {
                    Console.WriteLine($"Index: {i}, Wert: {MyArray[i]}");
                }
            }
        }
    }
}
