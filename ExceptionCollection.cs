namespace FlippyPuzzles {
	public static class ExceptionCollection {
		public static Exception BadMoveException(string moveString) {
			return new Exception($"Could not understand move {moveString}.");
		}
		public static Exception IndexOutOfRangeException(int index, int puzzleDimensions) {
			return new Exception($"Tried to flip at index {index} on a puzzle with dimensions {puzzleDimensions}x{puzzleDimensions}.");
		}
	}
}
