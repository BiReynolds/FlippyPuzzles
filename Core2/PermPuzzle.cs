namespace Core2
{
    public class PermPuzzle
    {
        public int NumPieces;
        protected PermPuzzleFrame Frame;
        protected Dictionary<string, int[]> MoveDictionary = new();
        public PermPuzzle(int numPieces)
        {
            NumPieces = numPieces;
            Frame = new(numPieces);
        }
        public void ApplyMove(string moveName)
        {
            int[] perm = MoveDictionary[moveName];
            Frame.CurrentState = PermHelper.ApplyPermToState(perm, Frame.CurrentState);
        }
        public void AddMove(string moveName, int[] moveData)
        {
            MoveDictionary[moveName] = moveData;
        }
        public string[] GetMoveList()
        {
            return [.. MoveDictionary.Keys];
        }
        public int[] GetState()
        {
            return Frame.CurrentState;
        }
    }
}