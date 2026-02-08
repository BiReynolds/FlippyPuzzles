namespace PuzzleSourceGraph {
	public class PuzzleStateNode {
		public int PieceValue;
		public int[] Sources;
		public PuzzleStateNode(int pieceVal, string[] moveList, Dictionary<string, int[]> moveDict) {
			PieceValue = pieceVal;
			Sources = (from move in moveList select moveDict[move][pieceVal]).ToArray();
		}
	}
}
