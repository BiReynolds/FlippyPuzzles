namespace PermPuzzleCore
{
    public class PuzzleTrigger
    {
        public int Layer, Id;
        public readonly int PermLength;
        public readonly int[] EffectPerm;
        public readonly PuzzleTrigger[] SubTriggers;
        public PuzzleTrigger(int[] effectPerm, IEnumerable<PuzzleTrigger> subTriggers)
        {
            PermLength = effectPerm.Length;
            EffectPerm = effectPerm;
            SubTriggers = subTriggers.ToArray();
        }

        public PuzzleTrigger(int permLength)
        {
            PermLength = permLength;
            EffectPerm = PermHelper.CreateIdPerm(permLength);
            SubTriggers = [];
        }

        public PuzzleTrigger(int[] effectPerm)
        {
            PermLength = effectPerm.Length;
            EffectPerm = effectPerm;
            SubTriggers = [];
        }

        public List<int> GetFullTrigger()
        {
            if (SubTriggers.Length == 0)
            {
                return [Id];
            }
            else
            {
                return UnpackSubTriggers();
            }
        }

        public List<int> UnpackSubTriggers()
        {
            List<int> result = new();
            foreach (PuzzleTrigger trigger in SubTriggers)
            {
                result.AddRange(trigger.GetFullTrigger());
            }
            return result;
        }

        public override string ToString()
        {
            string result = "[";
            foreach (PuzzleTrigger trigger in SubTriggers)
            {
                result += $"{trigger.Id} ";
            }
            result += "] : ";
            result += PermHelper.PermToString(EffectPerm);
            return result;
        }
    }
}