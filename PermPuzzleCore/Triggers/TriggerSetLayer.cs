namespace PermPuzzleCore
{
    public class TriggerSetLayer
    {
        readonly int LayerNumber;
        List<PuzzleTrigger> Triggers = new();

        public TriggerSetLayer(int layerNumber)
        {
            // this constructor is only meant to be used for the "zeroth" layer
            LayerNumber = layerNumber;
        }

        public static TriggerSetLayer GetZeroLayer(int numPieces)
        {
            PuzzleTrigger idTrigger = new(numPieces);
            TriggerSetLayer result = new(0);
            result.AddIfNew(idTrigger);
            return result;
        }

        public void AddIfNew(PuzzleTrigger trigger)
        {
            PuzzleTrigger? conflict = FindTriggerByPerm(trigger.EffectPerm);
            if (conflict == null)
            {
                trigger.Id = Triggers.Count;
                Triggers.Add(trigger);
            }
        }

        public void AddRangeIfNew(IEnumerable<PuzzleTrigger> triggers)
        {
            foreach (PuzzleTrigger trigger in triggers)
            {
                AddIfNew(trigger);
            }
        }

        public PuzzleTrigger? FindTriggerByPerm(int[] perm)
        {
            return Triggers.FirstOrDefault((x)=>{ return PermHelper.CheckEqual(x.EffectPerm, perm); });
        }

        public PuzzleTrigger GetTriggerById(int id)
        {
            return Triggers[id];
        }

        public int GetNumberOfTriggers()
        {
            return Triggers.Count;
        }
    }
}