
namespace Core2
{
    public static class PermHelper
    {
        public static string PermToString(int[] perm)
        {
            string result = "<";
            foreach (int address in perm)
            {
                result += $"{address},";
            }
            result = result[..^1] + ">";
            return result;
        }
		public static int[] GetIdPerm(int length)
		{
			int[] result = new int[length];
			for (int i = 0; i < length; i++)
			{
				result[i] = i;
			}
			return result;
		}
        public static int[] ApplyPermToState(int[] perm, int[] state)
        {
            // Note: to avoid superfluous checks of perm / state length, this method assumes that perm and state have the same length
            // i.e. make sure to add a check for this somewhere upstream, like in the puzzle initialization, that way it only needs to be checked once
            int[] result = new int[state.Length];
            for (int i = 0; i < perm.Length; i++)
            {
                result[i] = perm[state[i]];
            }
            return result;
        }
    }
}