using Spectre.Console;
using System.Linq;

namespace FinalPr
{
    public class MenuManager
    {
        private readonly EntryManager _manager;
        private readonly string _entryType;

        public MenuManager(EntryManager manager, string entryType)
        {
            _manager = manager;
            _entryType = entryType;
        }

        public void ShowMenu()
        {
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"[blue]{_entryType.Capitalize()} Menu[/]")
                        .AddChoices("View History", "Log Entry", "Delete Entry", "Exit"));

                switch (choice)
                {
                    case "View History":
                        _manager.ViewHistory(_entryType);
                        break;
                    case "Log Entry":
                        _manager.LogEntry($"Enter {_entryType} details:");
                        break;
                    case "Delete Entry":
                        _manager.DeleteEntry(_entryType);
                        break;
                    case "Exit":
                        return;
                }
            }
        }
    }

    static class StringExtensions
    {
        public static string Capitalize(this string input) =>
            string.IsNullOrEmpty(input)
                ? input
                : char.ToUpper(input[0]) + input.Substring(1);
    }
}
