namespace PermPuzzleCore
{
    public class PermPuzzle : PermPuzzleFrame
    {
        private Dictionary<string, int[]> MoveDictionary = new();
        public PermPuzzle(int N, Dictionary<string, int[]> moveDictionary) : base(N)
        {
            if (AreInputsValid(N, moveDictionary))
            {
                MoveDictionary = moveDictionary;
            }
        }
        public bool AreInputsValid(int N, Dictionary<string, int[]> moveDictionary)
        {
            foreach (string move in moveDictionary.Keys)
            {
                int[] moveArray = moveDictionary[move];
                int moveLength = moveArray.Length;
                if (moveLength != N)
                {
                    throw new Exception($"Length of perm '{move}' does not match size of puzzle.  Puzzle has size {N} and perm = {PermHelper.PermToString(moveArray)} has length {moveLength}");
                }
            }
            return true;
        }
        public void ApplyMoves(string[] scramble)
        {
            foreach (string moveName in scramble)
            {
                ApplyMove(moveName);
            }
        }
        public void ApplyMove(string moveName)
        {
            int[] perm = MoveDictionary[moveName];
            ApplyPerm(perm);
        }

    }
}