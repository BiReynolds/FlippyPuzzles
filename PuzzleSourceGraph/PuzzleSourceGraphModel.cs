namespace PuzzleSourceGraph {
	public class PuzzleSourceGraphModel {
		public int NumPieces;
		public PuzzleStateNode[] Nodes;
		public PuzzleSourceGraphModel(string[] moveList, Dictionary<string, int[]> moveDict) {
			NumPieces = moveDict[moveList[0]].Length;
			Nodes = new PuzzleStateNode[NumPieces];
			for (int pieceVal = 0; pieceVal < NumPieces; pieceVal++) {
				Nodes[pieceVal] = new PuzzleStateNode(pieceVal, moveList, moveDict);
			}
		}
		public int[] GetDirectSources(int piece) {
			PuzzleStateNode node = Nodes[piece];
			return node.Sources;
		}
		public List<int> GetAllSources(int piece) {
			List<int> fullResult = new();
			List<int> newestSources = [piece];
			List<int> nextSources = new();
			while (newestSources.Count() > 0) {
				fullResult.AddRange(newestSources);
				nextSources.Clear();
				foreach (int source in newestSources) {
					nextSources.AddRange(GetDirectSources(source));
				}
				newestSources = nextSources.Where(source => !(fullResult.Contains(source))).Distinct().ToList();
			}
			return fullResult;
		}
		public List<int[]> GetAllSourceSets() {
			List<int[]> result = new();
			List<int> coveredPieces = new();
			for (int piece = 0; piece < NumPieces; piece++) {
				if (!coveredPieces.Contains(piece)) {
					int[] newSourceSet = GetAllSources(piece).ToArray();
					result.Add(newSourceSet);
					coveredPieces.AddRange(newSourceSet);
				}
			}
			return result;
		}
	}
}
