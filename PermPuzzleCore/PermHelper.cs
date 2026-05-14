namespace PermPuzzleCore
{
    public static class PermHelper
    {
        public static bool CheckEqual(int[] perm1, int[] perm2)
        {
            for(int i = 0; i < perm1.Length; i++)
            {
                if (perm1[i] != perm2[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static int[] CreateIdPerm(int permLength)
        {
            int[] result = new int[permLength];
            for (int i = 0; i < permLength; i++)
            {
                result[i] = i;
            }
            return result;
        }

        public static int[] CreateSwapPerm(int permLength, int flipIndex)
        {
            if (permLength <= 1)
            {
                throw new Exception("Cannot create flip perm with permLength <= 1");
            }
            if (flipIndex < 0 || flipIndex >= permLength - 2)
            {
                throw new Exception($"Cannot create flip perm with perm length {permLength} and flip index {flipIndex}.\n" + 
                $"For this perm length, the flip index must be between 0 and {permLength - 2}");
            }
            int[] result = CreateIdPerm(permLength);
            (result[flipIndex + 1], result[flipIndex]) = (result[flipIndex], result[flipIndex + 1]);
            return result;
        }

        public static int[] CreateShiftPerm(int permLength, bool rightShift = false)
        {
            if (permLength == 0)
            {
                throw new Exception("Cannot create shift perm with permLength 0");
            }
            int[] result = new int[permLength];
            if (rightShift)
            {
                result[0] = permLength - 1;
                for (int i = 0; i < permLength - 1; i++)
                {
                    result[i + 1] = i;
                }
                return result;
            }
            else
            {
                result[permLength - 1] = 0;
                for (int i = 0; i < permLength - 1; i++)
                {
                    result[i] = i + 1;
                }
                return result;
            }
        }
        
        public static int[] ApplyPermToState(int[] perm, int[] state)
        {
            int[] result = new int[state.Length];
            foreach (int address in perm)
            {
                result[address] = state[perm[address]];
            }
            return result;
        }

        public static string PermToString(int[] perm)
        {
            string result = "<";
            foreach (int val in perm)
            {
                result += $"{val}, ";
            }
            if (result.Length > 2)
            {
                result = result[..^2] + ">";
            }
            else
            {
                result += ">";
            }
            return result;
        }
    }
}