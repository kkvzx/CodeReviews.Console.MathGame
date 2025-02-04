using MathGame.classes.shared;

namespace MathGame.classes.competitions.shared;

public class BaseCompetition : BaseConsole
{
    public const int CompetitionReps = 5;

    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; } = DateTime.Now;
    public int Score { get; set; }
    public int RemainingReps { get; set; } = CompetitionReps;

    public double CompletionTime()
    {
        return Math.Round((EndTime - StartTime).TotalSeconds, 2);
    }
}
