namespace Core {
	public static class FlippyPuzzleFactory {
		public static FlippyPuzzleModel GetStandardPuzzle(int dimensions) {
			int[] solvedState = GetStandardSolvedState(dimensions);
			Dictionary<string, int[]> moveDict = GetStandardMoveDictionary(dimensions, solvedState);
			return new FlippyPuzzleModel(dimensions, solvedState, moveDict);
		}
		private static int[] GetStandardSolvedState(int dimensions) {
			int[] result = new int[dimensions * dimensions];
			for (int i = 0; i < dimensions * dimensions; i++) {
				result[i] = i;
			}
			return result;
		}
		private static Dictionary<string, int[]> GetStandardMoveDictionary(int dimensions, int[] solvedState) {
			Dictionary<string, int[]> result = new();
			for (int row = 0; row < dimensions; row++) {
				string newMoveString = $"r{row}";
				int[] permArray = GetRowFlipAsPermArray(solvedState, dimensions, row);
				result[newMoveString] = permArray;
			}
			for (int col = 0; col < dimensions; col++) {
				string newMoveString = $"c{col}";
				int[] permArray = GetColFlipAsPermArray(solvedState, dimensions, col);
				result[newMoveString] = permArray;
			}
			result["s0"] = GetClockwiseRotationAsPermArray(solvedState, dimensions);
			result["s1"] = GetCounterClockwiseRotationAsPermArray(solvedState, dimensions);
			return result;
		}
		private static int[] GetRowFlipAsPermArray(int[] solvedState, int dimensions, int rowNum) {
			return MatrixHelper.FlipRow(solvedState, dimensions, rowNum);
		}
		private static int[] GetColFlipAsPermArray(int[] solvedState, int dimensions, int colNum) {
			return MatrixHelper.FlipCol(solvedState, dimensions, colNum);
		}
		private static int[] GetClockwiseRotationAsPermArray(int[] solvedState, int dimensions) {
			return MatrixHelper.RotateClockwise(solvedState, dimensions);
		}
		private static int[] GetCounterClockwiseRotationAsPermArray(int[] solvedState, int dimensions) {
			return MatrixHelper.RotateCounterClockwise(solvedState, dimensions);
		}
	}
}
