using Spectre.Console;

namespace FinalPr
{
    public class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Clear();
            string userName = AnsiConsole.Ask<string>("[blue]Enter your name:[/] ");
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
                        new MenuManager(new EntryManager("symptoms.txt"), "symptom").ShowMenu();
                        break;
                    case "Medication":
                        new MenuManager(new EntryManager("medication.txt"), "medication").ShowMenu();
                        break;
                    case "Calendar":
                        new MenuManager(new EntryManager("appointments.txt"), "appointment").ShowMenu();
                        break;
                    case "Exit":
                        return;
                }
            }
        }
    }
}
