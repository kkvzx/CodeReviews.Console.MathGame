using MathGame.enums;

namespace MathGame.classes.competitions.shared.MathCompetition;

public class MathCompetition : BaseCompetition
{
    private readonly Func<int, int, int> _operation;
    private readonly string _symbol;
    private readonly DifficultyLevel _difficultyLevel;

    protected MathCompetition(Func<int, int, int> operation, string symbol, DifficultyLevel difficultyLevel)
    {
        _operation = operation;
        _symbol = symbol;
        _difficultyLevel = difficultyLevel;
    }
    
    public void Start()
    {
        StartTime = DateTime.Now;
        while (RemainingReps > 0)
        {
            Guess();
            RemainingReps--;
        }

        EndTime = DateTime.Now;

        ShowSummary();

    }
    
    private void Guess()
    {
        Competition competition = new(difficultyLevel: _difficultyLevel, isDividable: _symbol == "/");
        int correctAnswer = _operation(competition.FirstNumber, competition.SecondNumber);

        Console.Write($"{competition.FirstNumber} {_symbol} {competition.SecondNumber} = ");
        string? userGuess = Console.ReadLine();
        string historyEntry = $"{competition.FirstNumber} {_symbol} {competition.SecondNumber} = {userGuess}";

        if (!int.TryParse(userGuess, out var convertedUserGuess))
        {
            Console.WriteLine("You didn't enter a valid integer. You lose this point :(");
            AddHistoryEntry($"{historyEntry}\tIncorrect input");
        }
        else if (convertedUserGuess == correctAnswer)
        {
            Console.WriteLine("Nice! Correct guess");
            Score++;
            AddHistoryEntry($"{historyEntry}\tCorrect");
        }
        else
        {
            Console.WriteLine($"Unfortunately, your answer is not correct. Correct answer is {correctAnswer}");
            AddHistoryEntry($"{historyEntry}\tIncorrect");
        }

        PressKeyToClear();
    }

    private void ShowSummary()
    {
        string summary = $"You've scored {Score} out of {CompetitionReps}\nCompletion time: {CompletionTime()}s\n";
        Console.Write(summary);
        AddHistoryEntry(summary);
        PressKeyToClear();

    }
}
