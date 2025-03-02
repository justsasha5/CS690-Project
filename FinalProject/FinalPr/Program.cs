using System;
using System.IO;

namespace FinalPr
{
    class Program
    {
    static string userName;

    static void Main()
    {
        Console.Write("Enter your name: ");
        userName = Console.ReadLine();
        Console.WriteLine($"Hi {userName}\n");
        MainMenu();
    }


        static void  MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Hi {userName}!");
                Console.WriteLine("Symptoms");
                Console.WriteLine("Medication");
                Console.WriteLine("Calendar");
                Console.WriteLine("[X] Exit");
                Console.Write("Choose an option: ");
                
                string choice = Console.ReadLine();
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
                    case "X":
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void SymptomsMenu()
        {
            Console.Clear();
            Console.WriteLine("Symptoms");
            Console.WriteLine("[1] Log Symptom");
            Console.WriteLine("[2] View History");
            Console.WriteLine("[X] Back");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter date (YYYY-MM-DD): ");
                string date = Console.ReadLine();
                Console.Write("Enter notes: ");
                string notes = Console.ReadLine();
              
            }
            else if (choice == "2")
            {
                // history
            }
        }

        static void MedicationMenu()
        {
            Console.Clear();
            Console.WriteLine("Medication");
            Console.WriteLine("[1] Log Medication");
            Console.WriteLine("[2] View History");
            Console.WriteLine("[X] Back");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter date (YYYY-MM-DD): ");
                string date = Console.ReadLine();
                Console.Write("Enter notes: ");
                string notes = Console.ReadLine();
                // Store data logic here
            }
            else if (choice == "2")
            {
                //history
            }
        }

        static void CalendarMenu()
        {
            Console.Clear();
            Console.WriteLine("Calendar");
            Console.WriteLine("[1] Log Appointment");
            Console.WriteLine("[2] View Upcoming Appointments");
            Console.WriteLine("[X] Back");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter date (YYYY-MM-DD): ");
                string date = Console.ReadLine();
                Console.Write("Enter notes: ");
                string notes = Console.ReadLine();
                // Store data logic here
            }
            else if (choice == "2")
            {
                //  upcoming appointments
            }
        }
    }
}
