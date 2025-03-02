using System;
using System.IO;
using System.Collections.Generic;

namespace FinalPr
{
    class Program
    {
        static void Main(string[] args)
        {   Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Hi {userName}!");
                Console.WriteLine("Symptoms");
                Console.WriteLine("Medication");
                Console.WriteLine("Calendar");
                Console.WriteLine("[X] Exit");
                Console.Write("Choose an option: ");
                
                string choice = Console.ReadLine.ToLower();
                switch (choice)
                {
                    case "symptoms":
                        SymptomsMenu();
                        break;
                    case "medication":
                        MedicationMenu();
                        break;
                    case "calendar":
                        CalendarMenu();
                        break;
                    case "X":
                        return;
                }
            }
        }


         static void SymptomsMenu()
        {
            while (true)
            {
                Console.WriteLine("Symptoms");
                Console.WriteLine("View History");
                Console.WriteLine("Log Symptom");
                Console.WriteLine("[X] Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine().ToLower();
                
                if (choice == "view history")
                    ViewHistory("symptoms.txt");
                else if (choice == "log symptom")
                    LogEntry("symptoms.txt", "Enter symptom details:");
                    // add options for Notes field and date
                    // ? option of mini calendar preview?
                    // smth to check for invalid date?

                else (choice == "x")
                    break;
            }
        }

        static void MedicationMenu()
        {
            while (true)
            {
                Console.WriteLine("Medication");
                Console.WriteLine("View History");
                Console.WriteLine("Log Medication");
                Console.WriteLine("[X] Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine().ToLower();
                
                if (choice == "view history")
                    ViewHistory("medication.txt");
                else if (choice == "log medication")
                    LogEntry("medication.txt", "Enter medication details:");
                    // add options for Notes field and date
                    // ? option of mini calendar preview?
                    // smth to check for invalid date?

                else (choice == "x")
                    break;
            }
        }


        static void CalendarMenu()
        {
            while (true)
            {
                Console.WriteLine("Calendar");
                Console.WriteLine("View Upcoming Appointments");
                Console.WriteLine("Log Appointment");
                Console.WriteLine("[X] Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine().ToLower();

                if (choice == "view upcoming appointments")
                    ViewHistory("appointments.txt");
                else if (choice == "log appointment")
                    LogEntry("appointments.txt", "Enter appointment details:");
                    // add options for Notes field and date
                    // ? option of mini calendar preview?
                    // smth to check for invalid date?
                else (choice == "x")
                    break;
            }
        }

        // Defining logging entry and viewing history
        // Log entry will log in appropriate txt file to store data

        static void LogEntry(string fileName, string prompt)
        {
            Console.Write(prompt + " ");
            string details = Console.ReadLine();
            Console.Write("Enter date (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            
            File.AppendAllText(fileName, $"{date}: {details}\n");
            Console.WriteLine("Entry saved.");
        }

        // view history show appropriate txt file with history
        static void ViewHistory(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] entries = File.ReadAllLines(fileName);
                foreach (string entry in entries)
                    Console.WriteLine(entry);
            }
            else
                Console.WriteLine("No history found.");
        }
    }
}
