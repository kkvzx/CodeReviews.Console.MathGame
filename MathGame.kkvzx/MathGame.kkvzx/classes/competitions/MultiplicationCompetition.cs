using MathGame.classes.competitions.shared.MathCompetition;
using MathGame.enums;

namespace MathGame.classes.competitions;

public class MultiplicationCompetition(DifficultyLevel difficultyLevel)
    : MathCompetition((a, b) => a * b, "*", difficultyLevel);
