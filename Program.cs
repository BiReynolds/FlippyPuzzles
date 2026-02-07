using Core;
using CLI;

public static class Program {
	public static void Main() {
		FlippyPuzzleModel Puzzle = FlippyPuzzleFactory.GetStandardPuzzle(3);
		PuzzleCLI Game = new PuzzleCLI(Puzzle);
		Game.Start();
	}
}
