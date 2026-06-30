using System;
using System.Linq;

public sealed class ScoreBoard
{
    private readonly int[] _scores = new int[4];

    public ref int this[int index] => ref _scores[index];

    public override string ToString() => string.Join(", ", _scores.Select(score => score.ToString()));
}

public static class Program
{
    public static void Main()
    {
        ScoreBoard board = new ScoreBoard();
        board[0] = 10;

        ref int lateGameBonusSlot = ref board[2];
        lateGameBonusSlot = 42;

        Console.WriteLine(board);
    }
}
