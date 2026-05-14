namespace PermPuzzleCore.Solvers
{
    public interface IPermPuzzleSolver
    {
        public SolveSummary Solve(PermPuzzle puzzle);
    }
}