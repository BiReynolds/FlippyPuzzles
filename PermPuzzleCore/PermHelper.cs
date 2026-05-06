namespace PermPuzzleCore
{
    public static class PermHelper
    {
        public static int[] CreateIdPerm(int permLength)
        {
            int[] result = new int[permLength];
            for (int i = 0; i < permLength; i++)
            {
                result[i] = i;
            }
            return result;
        }
        
        public static int[] ApplyPermToState(int[] perm, int[] state)
        {
            int[] result = new int[state.Length];
            foreach (int address in perm)
            {
                result[address] = state[address];
            }
            return result;
        }
        public static string PermToString(int[] perm)
        {
            string result = "<";
            foreach (int val in perm)
            {
                result += $"val, ";
            }
            result = result[..^2] + ">";
            return result;
        }
    }
}