namespace Core2
{
    public class PermPuzzleFrame
    {
        public readonly int NumAddresses;
        public int[] CurrentState;
        public PermPuzzleFrame(int numAddresses)
        {
            NumAddresses = numAddresses;
            CurrentState = PermHelper.GetIdPerm(numAddresses);
        }
    }
}