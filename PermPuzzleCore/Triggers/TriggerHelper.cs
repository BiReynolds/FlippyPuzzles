namespace PermPuzzleCore
{
    public static class TriggerHelper
    {
        public static List<PuzzleTrigger> CreateTriggerDictFromMoveList(List<int[]> moveList)
        {
            // TODO
            List<PuzzleTrigger> result = new();
            return result;
        }

        public static PuzzleTrigger ApplyMoveToTrigger(PuzzleTrigger moveTrigger, PuzzleTrigger otherTrigger)
        {
            int permLength = moveTrigger.PermLength;
            int[] effectPerm = PermHelper.ApplyPermToState(moveTrigger.EffectPerm, otherTrigger.EffectPerm);
            PuzzleTrigger[] subTriggers = [.. otherTrigger.SubTriggers, moveTrigger];
            return new PuzzleTrigger(effectPerm, subTriggers);
        }

        public static PuzzleTrigger ComposeTriggers(PuzzleTrigger trig1, PuzzleTrigger trig2)
        {
            int permLength = trig1.PermLength;
            int[] effectPerm = PermHelper.ApplyPermToState(trig2.EffectPerm, trig1.EffectPerm);
            PuzzleTrigger[] subTriggers = [.. trig1.SubTriggers, .. trig2.SubTriggers];
            return new PuzzleTrigger(effectPerm, subTriggers);
        }
    }
}