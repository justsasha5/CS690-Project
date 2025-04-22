using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Spectre.Console;

namespace FinalPr
{
    public class EntryManager
    {
        private readonly string _filePath;
        private readonly FileSaver _fileSaver;

        public EntryManager(string filePath)
        {
            _filePath = filePath;
            _fileSaver = new FileSaver(filePath);
        }

        public void LogEntry(string prompt)
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

            _fileSaver.AppendLine($"{date}: {details}");
            AnsiConsole.MarkupLine("[green]Entry saved![/]");
            Console.ReadKey();
        }

        public void ViewHistory(string entryType)
        {
            AnsiConsole.Clear();

            if (!File.Exists(_filePath))
            {
                AnsiConsole.MarkupLine($"[red]No {entryType} history found.[/]");
                Console.ReadKey();
                return;
            }

            var entries = File.ReadAllLines(_filePath);
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

                if (choice == "Exit")
                    break;

                AnsiConsole.MarkupLine($"[yellow]{choice}[/]");
                Console.ReadKey();
            }
        }

        public void DeleteEntry(string entryType)
        {
            AnsiConsole.Clear();

            if (!File.Exists(_filePath))
            {
                AnsiConsole.MarkupLine($"[red]No {entryType} entries found.[/]");
                Console.ReadKey();
                return;
            }

            var entries = File.ReadAllLines(_filePath);
            if (entries.Length == 0)
            {
                AnsiConsole.MarkupLine($"[red]No {entryType} entries to delete.[/]");
                Console.ReadKey();
                return;
            }

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[blue]Select a {entryType} to delete or Exit:[/]")
                    .AddChoices(entries.Append("Exit").ToArray()));

            if (choice == "Exit")
                return;

            var updated = new List<string>(entries);
            updated.Remove(choice);
            File.WriteAllLines(_filePath, updated);

            AnsiConsole.MarkupLine($"[green]{entryType} deleted.[/]");
            Console.ReadKey();
        }
    }
}
