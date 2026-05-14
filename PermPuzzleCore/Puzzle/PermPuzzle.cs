namespace PermPuzzleCore
{
    public class PermPuzzle : IPuzzle
    {
        public PermPuzzleFrame Frame;
        public List<int[]> MoveList = new();
        public PermPuzzle(int N, IEnumerable<int[]> moveList)
        {
            AreInputsValid(N, moveList);
            Frame = new(N);
            MoveList = moveList.ToList();
        }
        private void AreInputsValid(int N, IEnumerable<int[]> moveList)
        {
            foreach (int[] move in moveList)
            {
                int moveLength = move.Length;
                if (moveLength != N)
                {
                    throw new Exception($"Length of perm does not match size of puzzle.  Puzzle has size {N} and perm = {PermHelper.PermToString(move)} has length {moveLength}");
                }
            }
        }
        public void ApplyMove(int moveNumber)
        {
            Frame.ApplyPerm(MoveList[moveNumber]);
        }

        public void ApplyMoves(IEnumerable<int> moveCodes)
        {
            foreach (int moveCode in moveCodes)
            {
                ApplyMove(moveCode);
            }
        }

        public void Reset()
        {
            Frame.Reset();
        }

        public int GetSize()
        {
            return Frame.Size;
        }

        public int[] GetMoves()
        {
            int[] result = new int[MoveList.Count];
            for (int i = 0; i < MoveList.Count; i++)
            {
                result[i] = i;
            }
            return result;
        }

        public int[] GetState()
        {
            return Frame.GetState();
        }

        public int[] GetSolvedState()
        {
            return Frame.GetSolvedState();
        }

        public bool CheckSolved()
        {
            return Frame.CheckSolved();
        }

    }
}