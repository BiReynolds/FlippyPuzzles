namespace FlippyPuzzles {
	public class PuzzleCLI {
		private bool IsRunning = true;
		private FlippyPuzzleModel Puzzle = new FlippyPuzzleModel(3);
		public Dictionary<string, Action> SpecialCommands = new();
		public PuzzleCLI() {
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
			char RowOrCol = ParseRowOrColFromString(rawInput);
			int Index = ParseIndexFromString(lowerInput);
			ApplyMove(RowOrCol, Index);
		}
		private char ParseRowOrColFromString(string inputString) {
			char result = inputString[0];
			if (result == 'r' || result == 'c') {
				return result;
			}
			else {
				throw ExceptionCollection.BadMoveException(inputString);
			}
		}
		private int ParseIndexFromString(string inputString) {
			try {
				return int.Parse(inputString[1..]);
			} 
			catch {
				throw ExceptionCollection.BadMoveException(inputString);
			}
		}
		private void ApplyMove(char rowOrCol, int index) {
			if (index < 0 || index >= Puzzle.Dimensions) {
				throw ExceptionCollection.IndexOutOfRangeException(index, Puzzle.Dimensions);
			}
			if (rowOrCol == 'r') {
				Puzzle.FlipRow(index);
				return;
			} 
			else {
				Puzzle.FlipCol(index);
				return;
			}
		}
		public void Exit() {
			IsRunning = false;
		}
	}
}
