namespace PermPuzzleCore.Solvers
{
    public class SolveSummary
    {
        bool DidSolve;
        int[] StartState;
        List<int> Moves;
        public SolveSummary(int[] startState, IEnumerable<int> moves, bool didSolve)
        {
            StartState = startState;
            Moves = [.. moves];
            DidSolve = didSolve;
        }
    }
}