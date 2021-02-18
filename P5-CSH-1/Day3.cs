using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace P5_CSH_1 {
    class Day3 : Day {
        public Day3() : base(3) {
            addAufgabe("Datenbanken: Aufgabe 1", Exercise01);
        }

        public void Exercise01() {
            Db1 db1 = new Db1();
            MySqlConnection con = db1.Connect();
            db1.Show();
            db1.Disconnect();
        }

        class Db1 {
            public static MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=;database=csh1");
            public MySqlConnection Connect() {
                try {
                    connection.Open();
                    Console.WriteLine("Verbindung hergestellt!");
                } catch (MySqlException e) {
                    Console.WriteLine("Verbindung fehlgeschlagen: " + e.Message);
                }
                return connection;
            }
            public void Disconnect() {
                try {
                    connection.Close();
                    Console.WriteLine("Verbindung geschlossen!");
                } catch (MySqlException e) {
                    Console.WriteLine("Verbindung fehlgeschlagen: " + e.Message);
                }
            }
            public void Show() {
                try {
                    Console.WriteLine("Welche Tabelle?");
                    MySqlCommand command = new MySqlCommand("SHOW TABLES;", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<string> tables = new List<string>();
                    int zaehler = 0;
                    while (reader.Read()) {
                        Console.WriteLine($"({zaehler}) - {reader[0]}");
                        zaehler++;
                        tables.Add(reader[0].ToString());
                    }
                    Console.Write(" ");
                    reader.Close();

                    int auswahl;
                    Int32.TryParse(Console.ReadLine(), out auswahl);
                    command = new MySqlCommand($"SHOW COLUMNS FROM {tables[auswahl]};", connection);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Console.Write("{0, -15}", reader[0]);
                    }
                    Console.WriteLine();
                    reader.Close();

                    command = new MySqlCommand($"SELECT * FROM {tables[auswahl]};", connection);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        for (int i = 0; i < reader.FieldCount; i++) {
                            Console.Write("{0, -15}", reader[i]);
                        }
                        Console.WriteLine();
                    }
                    reader.Close();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
