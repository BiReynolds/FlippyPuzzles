namespace PermPuzzleCore
{
    public static class PermPuzzleFactory
    {
        public static PermPuzzle CreatePuzzle(int puzzleSize, PermPuzzleType puzzleType)
        {
            List<int[]> moves;
            switch (puzzleType)
            {
                case PermPuzzleType.ShiftAndSwap:
                    moves = GetShiftAndSwapPuzzleMoveList(puzzleSize);
                    break;
                case PermPuzzleType.Swap:
                    moves = GetSwapPuzzleMoveList(puzzleSize);
                    break;
                default:
                    throw new Exception($"PermPuzzleFactory received an unknown value for PermPuzzleTypeEnum: {puzzleType}");
            }
            return new PermPuzzle(puzzleSize, moves);
        }
        private static List<int[]> GetSwapPuzzleMoveList(int puzzleSize)
        {
            List<int[]> result = [];
            for (int i = 0; i < puzzleSize - 1; i++)
            {
                result.Add(PermHelper.CreateSwapPerm(puzzleSize, i));
            }
            return result;
        }
        
        private static List<int[]> GetShiftAndSwapPuzzleMoveList(int puzzleSize)
        {
            List<int[]> result = [];
            result.Add(PermHelper.CreateShiftPerm(puzzleSize));
            result.Add(PermHelper.CreateSwapPerm(puzzleSize, 0));
            return result;
        }

        public static List<string> GetPuzzleMoveNames(int puzzleSize, PermPuzzleType puzzleType)
        {
            switch (puzzleType)
            {
                case PermPuzzleType.ShiftAndSwap:
                    return GetShiftAndSwapPuzzleMoveNames();
                case PermPuzzleType.Swap:
                    return GetSwapPuzzleMoveNames(puzzleSize);
                default:
                    throw new Exception($"PermPuzzleFactory received an unknown value for PermPuzzleTypeEnum: {puzzleType}");

            }
        }

        public static List<string> GetSwapPuzzleMoveNames(int puzzleSize)
        {
            List<string> result = new();
            for (int i = 0; i < puzzleSize - 1; i++)
            {
                result.Add($"s{i}");
            }
            return result;
        }
        
        public static List<string> GetShiftAndSwapPuzzleMoveNames()
        {
            return ["shift", "swap"];
        }
    }
}