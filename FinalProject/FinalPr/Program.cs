using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Spectre.Console;
using System.Linq;

namespace FinalPr
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Clear();
            string userName = AnsiConsole.Ask<string>("[green]Enter your name:[/] ");
            AnsiConsole.Clear();

            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine($"[bold yellow]Hi {userName}![/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue]Choose an option:[/]")
                        .AddChoices("Symptoms", "Medication", "Calendar", "Exit"));

                switch (choice)
                {
                    case "Symptoms":
                        SymptomsMenu();
                        break;
                    case "Medication":
                        MedicationMenu();
                        break;
                    case "Calendar":
                        CalendarMenu();
                        break;
                    case "Exit":
                        return;
                }
            }
        }

        static void SymptomsMenu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue]Symptoms Menu[/]")
                        .AddChoices("View History", "Log Symptom", "Delete Symptom", "Exit"));

                if (choice == "View History")
                    ViewDetailedHistory("symptoms.txt", "symptom");
                else if (choice == "Log Symptom")
                    LogEntry("symptoms.txt", "Enter symptom details:");
                else if (choice == "Delete Symptom")
                    DeleteEntry("symptoms.txt", "symptom");
                else if (choice == "Exit")
                    break;
            }
        }

        static void MedicationMenu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue]Medication Menu[/]")
                        .AddChoices("View History", "Log Medication", "Delete Medication", "Exit"));

                if (choice == "View History")
                    ViewDetailedHistory("medication.txt", "medication");
                else if (choice == "Log Medication")
                    LogEntry("medication.txt", "Enter medication details:");
                else if (choice == "Delete Medication")
                    DeleteEntry("medication.txt", "medication");
                else if (choice == "Exit")
                    break;
            }
        }

        static void CalendarMenu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue]Calendar Menu[/]")
                        .AddChoices("View Appointments", "Log Appointment", "Delete Appointment", "Exit"));

                if (choice == "View Appointments")
                    ViewDetailedHistory("appointments.txt", "appointment");
                else if (choice == "Log Appointment")
                    LogEntry("appointments.txt", "Enter appointment details:");
                else if (choice == "Delete Appointment")
                    DeleteEntry("appointments.txt", "appointment");
                else if (choice == "Exit")
                    break;
            }
        }

        static void LogEntry(string fileName, string prompt)
        {
            string details = AnsiConsole.Ask<string>($"[green]{prompt}[/]");
            string date;

            while (true)
            {
                date = AnsiConsole.Ask<string>("[green]Enter date (YYYY-MM-DD):[/]");
                if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    break;
                AnsiConsole.MarkupLine("[red]Invalid date format. Try again.[/]");
            }

            File.AppendAllText(fileName, $"{date}: {details}\n");
            AnsiConsole.MarkupLine("[green]Entry saved![/]");
            Console.ReadKey();  
        }

static void ViewDetailedHistory(string fileName, string entryType)
{
    AnsiConsole.Clear();
    
    if (File.Exists(fileName))
    {
        string[] entries = File.ReadAllLines(fileName);
        
        if (entries.Length == 0)
        {
            AnsiConsole.MarkupLine($"[red]No {entryType} history to display.[/]");
            Console.ReadKey();
            return;
        }
        
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[blue]Select a {entryType} entry to view:[/]")
                    .AddChoices(entries.Append("Exit").ToArray()));

            if (choice == "Exit") break;

            AnsiConsole.MarkupLine($"[yellow]{choice}[/]");
            Console.ReadKey();
        }
    }
    else
    {
        AnsiConsole.MarkupLine($"[red]No {entryType} history found.[/]");
        Console.ReadKey();
    }
}


        static void DeleteEntry(string fileName, string entryType)
        {
            AnsiConsole.Clear();
            if (File.Exists(fileName))
            {
                string[] entries = File.ReadAllLines(fileName);
                if (entries.Length == 0)
                {
                    AnsiConsole.MarkupLine($"[red]No {entryType} entries to delete.[/]");
                    return;
                }

                while (true)
                {
                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"[blue]Select a {entryType} to delete or Exit:[/]")
                            .AddChoices(entries.Append("Exit").ToArray()));

                    if (choice == "Exit") break;
                    
                    var updatedEntries = new List<string>(entries);
                    updatedEntries.Remove(choice);
                    File.WriteAllLines(fileName, updatedEntries);

                    AnsiConsole.MarkupLine($"[green]{entryType} deleted.[/]");
                    break;  
                }
            }
            else
                AnsiConsole.MarkupLine($"[red]No {entryType} entries found.[/]");

        }
    }
}
