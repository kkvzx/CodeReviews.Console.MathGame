using MathGame.enums;

namespace MathGame.classes.competitions.shared.MathCompetition;

public class Competition
{
    private readonly DifficultyLevel _difficultyLevel;

    public int FirstNumber { get; }
    public int SecondNumber { get; }

    public Competition(DifficultyLevel difficultyLevel, bool isDividable = false)
    {
        _difficultyLevel = difficultyLevel;

        Random random = new();
        int endRange = GetEndRangeBasedOnDifficultyLevel();

        do
        {
            FirstNumber = random.Next(1, endRange);
            SecondNumber = random.Next(1, endRange);
        } while (FirstNumber % SecondNumber != 0 && isDividable);
    }

    private int GetEndRangeBasedOnDifficultyLevel()
    {
        return _difficultyLevel switch
        {
            DifficultyLevel.Easy => 10,
            DifficultyLevel.Medium => 100,
            DifficultyLevel.Hard => 1000,
            _ => 50,
        };
    }
}
