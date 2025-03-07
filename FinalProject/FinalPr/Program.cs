using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

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
                Console.WriteLine("1. Symptoms");
                Console.WriteLine("2. Medication");
                Console.WriteLine("3. Calendar");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                
                string choice = Console.ReadLine().ToLower();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        SymptomsMenu();
                        break;
                    case "2":
                        MedicationMenu();
                        break;
                    case "3":
                        CalendarMenu();
                        break;
                    case "4":
                        return;
                }
            }
        }


         static void SymptomsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Symptoms");
                Console.WriteLine("1. View History");
                Console.WriteLine("2. Log Symptom");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                    ViewHistory("symptoms.txt");
                else if (choice == "2")
                    LogEntry("symptoms.txt", "Enter symptom details:");
                else if (choice == "3")
                    break;
            }
        }


        static void MedicationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Medication");
                Console.WriteLine("1. View History");
                Console.WriteLine("2. Log Medication");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                    ViewHistory("medication.txt");
                else if (choice == "2")
                    LogEntry("medication.txt", "Enter medication details:");
                else if (choice == "3")
                    break;
            }
        }


         static void CalendarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Calendar");
                Console.WriteLine("1. View Upcoming Appointments");
                Console.WriteLine("2. Log Appointment");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                    ViewHistory("appointments.txt");
                else if (choice == "2")
                    LogEntry("appointments.txt", "Enter appointment details:");
                else if (choice == "3")
                    break;
            }
        }

        // Defining logging entry and viewing history 
        // Log entry will log in appropriate txt file to store data

        static void LogEntry(string fileName, string prompt)
        {
            Console.Write(prompt + " ");
            string details = Console.ReadLine();
            
            Console.Clear();
            Console.Write("Enter date (YYYY-MM-DD): ");
            string date;

            while (true)
            {
                date = Console.ReadLine();
                if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    break;
                Console.Write("Invalid date format. Enter again (YYYY-MM-DD): ");
            }

            File.AppendAllText(fileName, $"{date}: {details}\n");
            Console.WriteLine("Entry saved.");
        }

        static void ViewHistory(string fileName)
        {
            Console.Clear();
            if (File.Exists(fileName))
            {
                string[] entries = File.ReadAllLines(fileName);
                foreach (string entry in entries)
                    Console.WriteLine(entry);
            }
            else
                Console.WriteLine("No history found.");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}