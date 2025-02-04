using MathGame.classes.competitions;
using MathGame.classes.competitions.shared.MathCompetition;
using MathGame.classes.shared;
using MathGame.enums;

namespace MathGame.classes;

public class Game : BaseConsole
{
    private bool IsInProgress { get; set; } = true;

    private DifficultyLevel _difficultyLevel = DifficultyLevel.Easy;

    public void StartGame()
    {
        Console.WriteLine("Welcome to Math Game!");
        Console.WriteLine("---------------------");

        while (IsInProgress)
        {
            MenuOption selectedMenuOption = ShowMenu();
            HandleMenuItemChoice(selectedMenuOption);
        }
    }

    private static MenuOption ShowMenu()
    {
        string? userChoice;
        MenuOption selectedMenuOption;

        do
        {
            Console.WriteLine("Make a choice:");
            Console.WriteLine($"{(int)MenuOption.Addition}. Addition");
            Console.WriteLine($"{(int)MenuOption.Subtraction}. Subtraction");
            Console.WriteLine($"{(int)MenuOption.Multiplication}. Multiplication");
            Console.WriteLine($"{(int)MenuOption.Division}. Division");
            Console.WriteLine($"{(int)MenuOption.History}. History");
            Console.WriteLine();
            Console.WriteLine($"{(int)MenuOption.Settings}. Settings");
            Console.WriteLine($"{(int)MenuOption.ExitGame}. Exit the game");
            Console.WriteLine();
            Console.Write("Whats your choice?: ");

            userChoice = Console.ReadLine();
        } while (!Enum.TryParse(userChoice, out selectedMenuOption));

        return selectedMenuOption;
    }

    private void HandleMenuItemChoice(MenuOption userChoice)
    {
        Console.Clear();
        MathCompetition? selectedCompetition = userChoice switch
        {
            MenuOption.Addition => new AdditionCompetition(_difficultyLevel),
            MenuOption.Subtraction => new SubtractionCompetition(_difficultyLevel),
            MenuOption.Multiplication => new MultiplicationCompetition(_difficultyLevel),
            MenuOption.Division => new DivisionCompetition(_difficultyLevel),
            _ => null
        };

        switch (userChoice)
        {
            case MenuOption.Addition:
            case MenuOption.Subtraction:
            case MenuOption.Multiplication:
            case MenuOption.Division:
            {
                if (selectedCompetition is not null)
                {
                    StartCompetition(selectedCompetition);
                }

                break;
            }
            case MenuOption.History:
            {
                ShowHistory();
                break;
            }
            case MenuOption.Settings:
            {
                ShowSettings();
                break;
            }
            case MenuOption.ExitGame:
            {
                IsInProgress = false;
                break;
            }
        }
    }

    private void StartCompetition(MathCompetition competition)
    {
        competition.Start();
        History.AddRange(competition.History);
    }

    private void ShowSettings()
    {
        Console.Clear();
        Console.WriteLine("Select difficulty level: ");
        Console.WriteLine("1. Easy (range varies from 0 to 10)");
        Console.WriteLine("2. Medium (range varies from 0 to 100)");
        Console.WriteLine("3. Hard (range varies from 0 to 1000");
        var userInput = Console.ReadLine();

        if (!int.TryParse(userInput, out int difficulty) || difficulty > 3 || difficulty < 1)
        {
            Console.WriteLine("This is not a valid choice!");
            PressKeyToClear();

            return;
        }

        _difficultyLevel = (DifficultyLevel)(difficulty - 1);
        PressKeyToClear();
    }

    private void ShowHistory()
    {
        if (History.Count == 0)
        {
            Console.WriteLine("You haven't played any games yet. No history to show yet.");
            Console.WriteLine("Play some games in order to fill the history.");

            return;
        }

        foreach (var historyItem in History)
        {
            Console.WriteLine(historyItem);
        }

        PressKeyToClear();
    }
}
