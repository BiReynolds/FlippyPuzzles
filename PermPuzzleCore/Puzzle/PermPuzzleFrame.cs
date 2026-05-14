namespace PermPuzzleCore
{
    public class PermPuzzleFrame
    {
        public readonly int Size;
        private readonly int[] Addresses;
        private int[] State;
        public PermPuzzleFrame(int N)
        {
            Size = N;
            Addresses = PermHelper.CreateIdPerm(N);
            State = PermHelper.CreateIdPerm(N);
        }
        public void Reset()
        {
            Array.Copy(Addresses, State, Addresses.Length);
        }
        public void ApplyPerm(int[] perm)
        {
            State = PermHelper.ApplyPermToState(perm, State);
        }
        public bool CheckSolved()
        {
            foreach (int address in Addresses)
            {
                if (State[address] != address)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckSolvedWithMask(IEnumerable<int> mask)
        {
            foreach (int address in mask)
            {
                if (State[address] != address)
                {
                    return false;
                }
            }
            return true;
        }
        public int[] GetSolvedState()
        {
            return Addresses[..];
        }
        public int[] GetState()
        {
            return State[..];
        }
    }
}