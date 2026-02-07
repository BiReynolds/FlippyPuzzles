using Core;

namespace CLI {
	public class PuzzleCLI {
		private bool IsRunning = true;
		private FlippyPuzzleModel Puzzle;
		public Dictionary<string, Action> SpecialCommands = new();
		public PuzzleCLI(FlippyPuzzleModel puzzle) {
			Puzzle = puzzle;
			SpecialCommands["exit"] = Exit;
			SpecialCommands["reset"] = Puzzle.Reset;
			SpecialCommands["scramble"] = ()=>{ Puzzle.Scramble(10); };
		}
		public void Start() {
			while (IsRunning) {
				Render();
				string input = Console.ReadLine() ?? "";
				HandleInput(input);
			}
		}
		public void Render() {
			for (int row = 0; row < Puzzle.Dimensions; row++) {
				for (int col = 0; col < Puzzle.Dimensions; col++) {
					int val = Puzzle.State[row*Puzzle.Dimensions + col];
					string chunk = val.ToString() + " ";
					if (val < 10) {
						chunk = "0" + chunk;
					}
					Console.Write(chunk);
				}
				Console.WriteLine();
			}
		}
		public void HandleInput(string rawInput) {
			string lowerInput = rawInput.ToLower();
			if (SpecialCommands.ContainsKey(lowerInput)) {
				SpecialCommands[lowerInput]();
				return;
			}
			if (Puzzle.MoveDictionary.ContainsKey(lowerInput)) {
				Puzzle.ApplyMove(rawInput);
			}
			else {
				Console.WriteLine($"Could not understand input {lowerInput}.");
			}
		}
		public void Exit() {
			IsRunning = false;
		}
	}
}
