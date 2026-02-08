using PuzzleSourceGraph;

namespace CLI {
	public class SourceGraphCLI {
		public PuzzleSourceGraphModel SourceGraph;
		public SourceGraphCLI(string[] moveList, Dictionary<string, int[]> moveDict) {
			SourceGraph = new PuzzleSourceGraphModel(moveList, moveDict);
		}
		public bool HandleInput(string[] inputArray) {
			bool IsHandled = false;
			if (inputArray[0] == "sources" && inputArray.Length > 1) {
				if (int.TryParse(inputArray[1], out int piece)) {
					IsHandled = true;
					PrintSources(piece);
				}
				else {
					Console.WriteLine("sources command expects either no input, or a single integer.");
				}
			}
			else {
				IsHandled = true;
				PrintAllSourceSets();
			}
			return IsHandled;
		}
		public void PrintSources(int piece) {
			int[] sources = SourceGraph.GetAllSources(piece).ToArray();
			foreach (int source in sources) {
				Console.Write($"{source} ");
			}
			Console.WriteLine();
		}
		public void PrintAllSourceSets() {
			List<int[]> sourceSets = SourceGraph.GetAllSourceSets();
			foreach (int[] sourceSet in sourceSets) {
				Console.Write($"{sourceSet[0]} : ");
				foreach (int source in sourceSet) {
					Console.Write($"{source} ");
				}
				Console.WriteLine();
			}
		}
	}
}
