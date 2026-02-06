namespace FlippyPuzzles {
	public class FlippyPuzzleModel {
		public Random RNG = new Random();
		public readonly int Dimensions;
		public int[] State;
		public FlippyPuzzleModel(int dimensions) {
			Dimensions = dimensions;
			State = new int[dimensions*dimensions];
			for (int i = 0; i < dimensions * dimensions; i++) {
				State[i] = i;
			}
		}
		public void FlipRow(int rowNumber) {
			int[] tempState = State[..];
			int rowOffput = rowNumber * Dimensions;
			for (int i = 0; i < Dimensions; i++) {
				State[rowOffput + i] = tempState[rowOffput + Dimensions - i - 1];
			}
		}
		public void FlipCol(int colNumber) {
			int[] tempState = State[..];
			int colOffput = colNumber;
			for (int i = 0; i < Dimensions * Dimensions; i += Dimensions) {
				State[colOffput + i] = tempState[colOffput + Dimensions*(Dimensions - 1) - i];
			}
		}
		public void Scramble(int scramLength) {
			for (int i = 0; i < scramLength; i++) {
				DoRandomMove();
			}
		}
		public void DoRandomMove() {
			int rowOrCol = RNG.Next(0, 2);
			int index = RNG.Next(0, Dimensions);
			if (rowOrCol == 0) {
				FlipRow(index);
			}
			else {
				FlipCol(index);
			}
		}
		public void Reset() {
			for (int i = 0; i < Dimensions * Dimensions; i++) {
				State[i] = i;
			}
		}
	}
}
