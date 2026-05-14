namespace PermPuzzleCore
{
    public interface IPuzzle
    {
        public int GetSize();
        public int[] GetMoves();
        public int[] GetState();
        public int[] GetSolvedState();
        public bool CheckSolved();
        public void Reset();
        public void ApplyMove(int moveCode);
    }
}