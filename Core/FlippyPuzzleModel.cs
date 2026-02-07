namespace Core {
	public class FlippyPuzzleModel {
		public readonly Random RNG = new Random();
		public readonly int Dimensions;
		public readonly int NumMoves;
		public readonly Dictionary<string, int[]> MoveDictionary;
		public readonly int[] SolvedState;
		public int[] State;
		public FlippyPuzzleModel(int dimensions, int[] solvedState, Dictionary<string, int[]> moveDict) {
			Dimensions = dimensions;
			SolvedState = solvedState;
			MoveDictionary = moveDict;
			NumMoves = moveDict.Keys.Count;
			State = SolvedState;
		}
		public void Scramble(int scramLength) {
			for (int i = 0; i < scramLength; i++) {
				ApplyRandomMove();
			}
		}
		public void ApplyMoves(string[] moves) {
			foreach (string moveString in moves) {
				ApplyMove(moveString);
			}
		}
		public void ApplyMove(string moveString) {
			ApplyPerm(MoveDictionary[moveString]);
		}
		private void ApplyRandomMove() {
			string randMove = MoveDictionary.Keys.ToList()[RNG.Next(NumMoves)];
			ApplyMove(randMove);
		}
		private void ApplyPerm(int[] perm) {
			int[] newState = new int[State.Length];
			for (int i = 0; i < State.Length; i++) {
				newState[i] = State[perm[i]];
			}
			State = newState;
		}
		public void Reset() {
			for (int i = 0; i < Dimensions * Dimensions; i++) {
				State[i] = i;
			}
		}
	}
}
