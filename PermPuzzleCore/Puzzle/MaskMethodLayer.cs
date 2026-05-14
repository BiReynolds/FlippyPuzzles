namespace PermPuzzleCore
{
    public class MaskMethodLayer : IPuzzle
    {
        PermPuzzle BasePuzzle;
        int[] Mask;
        readonly int[] MaskedSolvedState;
        Dictionary<int, PuzzleTrigger> TriggerDictionary;
        public MaskMethodLayer(PermPuzzle basePuzzle, int[] mask, Dictionary<int, PuzzleTrigger> triggerDictionary)
        {
            BasePuzzle = basePuzzle;
            Mask = mask;
            MaskedSolvedState = GetMaskedState(basePuzzle.GetSolvedState());
            TriggerDictionary = triggerDictionary;
        }

        public int[] GetMaskedState(int[] baseState)
        {
            int[] result = baseState[..];
            for (int i = 0; i < baseState.Length; i++)
            {
                if (Mask.Contains(result[i]))
                {
                    result[i] = -1;
                }
            }
            return result;
        }

        public int[] GetState()
        {
            int[] baseState = BasePuzzle.GetState();
            return GetMaskedState(baseState);
        }

        public int[] GetSolvedState()
        {
            return MaskedSolvedState;
        }

        public bool CheckSolved()
        {
            return PermHelper.CheckEqual(GetState(), MaskedSolvedState);
        }

        public void Reset()
        {
            BasePuzzle.Reset();
        }

        public void ApplyMove(int moveCode)
        {
            PuzzleTrigger trigger = TriggerDictionary[moveCode];
            List<int> allMoves = trigger.GetFullTrigger();
            BasePuzzle.ApplyMoves(allMoves);
        }

        public int GetSize()
        {
            return BasePuzzle.GetSize();
        }

        public int[] GetMoves()
        {
            return [.. TriggerDictionary.Keys];
        }
    }
}