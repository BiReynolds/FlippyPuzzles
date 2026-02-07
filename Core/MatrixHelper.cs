namespace Core {
	public static class MatrixHelper {
		public static int GetValue(int[] matrixArray, int matrixSize, int row, int col) {
			int index = row * matrixSize + col;
			return matrixArray[index];
		}
		public static int[] RotateClockwise(int[] matrixArray, int matrixSize) {
			int[] result = Transpose(matrixArray, matrixSize);
			for (int row = 0; row < matrixSize; row++) {
				result = FlipRow(result, matrixSize, row);
			}
			return result;
		}
		public static int[] RotateCounterClockwise(int[] matrixArray, int matrixSize) {
			int[] result = Transpose(matrixArray, matrixSize);
			for (int col = 0; col < matrixSize; col++) {
				result = FlipCol(result, matrixSize, col);
			}
			return result;
		}
		public static int[] Transpose(int[] matrixArray, int matrixSize) {
			int[] result = new int[matrixArray.Length];
			for (int row = 0; row < matrixSize; row++) {
				for (int col = 0; col < matrixSize; col++) {
					result[row * matrixSize + col] = GetValue(matrixArray, matrixSize, col, row);
				}
			}
			return result;
		}
		public static int[] FlipRow(int[] matrixArray, int matrixSize, int rowNumber) {
			int[] result = matrixArray[..];
			int rowOffput = rowNumber * matrixSize;
			for (int i = 0; i < matrixSize; i++) {
				result[rowOffput + i] = matrixArray[rowOffput + matrixSize - i - 1];
			}
			return result;
		}
		public static int[] FlipCol(int[] matrixArray, int matrixSize, int colNumber) {
			int[] result = matrixArray[..];
			int colOffput = colNumber;
			for (int i = 0; i < matrixSize * matrixSize; i += matrixSize) {
				result[colOffput + i] = matrixArray[colOffput + matrixSize*(matrixSize - 1) - i];
			}
			return result;
		}
	}
}
