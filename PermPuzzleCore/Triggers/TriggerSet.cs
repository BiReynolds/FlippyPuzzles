using System.Runtime.Serialization;

namespace PermPuzzleCore
{
    public class TriggerSet
    {
        public bool Complete = false;
        public readonly int PuzzleSize;
        public readonly PuzzleTrigger[] BaseMoveList;
        public List<TriggerSetLayer> Layers = new();
        public TriggerSet(List<PuzzleTrigger> moveList, int maxTriggerLength)
        {
            PuzzleSize = moveList[0].PermLength;
            BaseMoveList = [..moveList];
            for (int i = 0; i < BaseMoveList.Length; i++)
            {
                BaseMoveList[i].Id = i;
            }
            Layers.Add(TriggerSetLayer.GetZeroLayer(PuzzleSize));
            for (int i = 0; i < maxTriggerLength; i++)
            {
                AddNextTriggerLayer();
                if (Layers.Last().GetNumberOfTriggers() == 0)
                {
                    Complete = true;
                    break;
                }
            }
        }

        public void AddNextTriggerLayer()
        {
            TriggerSetLayer lastLayer = Layers.Last();
            TriggerSetLayer newLayer = new(Layers.Count);
            for (int permId = 0; permId < lastLayer.GetNumberOfTriggers(); permId++)
            {
                PuzzleTrigger currTrigger = lastLayer.GetTriggerById(permId);
                List<PuzzleTrigger> newAdjacencies = GetNewTriggersAdjacentTo(currTrigger);
                newLayer.AddRangeIfNew(newAdjacencies);
            }
            Layers.Add(newLayer);
        }

        private List<PuzzleTrigger> GetNewTriggersAdjacentTo(PuzzleTrigger coreTrigger)
        {
            List<PuzzleTrigger> result = new();
            foreach (PuzzleTrigger moveTrigger in BaseMoveList)
            {
                int[] currPerm = PermHelper.ApplyPermToState(moveTrigger.EffectPerm, coreTrigger.EffectPerm);
                PuzzleTrigger? conflict = FindTriggerByPerm(currPerm);
                if (conflict == null)
                {
                    result.Add(TriggerHelper.ApplyMoveToTrigger(moveTrigger, coreTrigger));
                }
            }
            return result;
        }

        public PuzzleTrigger? FindTriggerByPerm(int[] perm)
        {
            foreach (TriggerSetLayer layer in Layers)
            {
                PuzzleTrigger? result = layer.FindTriggerByPerm(perm);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public int GetNumLayers()
        {
            if (Complete)
            {
                // if the trigger set is complete, then it includes an empty layer at the end.  We don't really want to include that one
                return Layers.Count - 1;
            }
            else
            {
                return Layers.Count;
            }
        }

        public int GetNumTriggers()
        {
            return Layers.Sum((x)=>{ return x.GetNumberOfTriggers(); });
        }

        public override string ToString()
        {
            string result = "TriggerSet\n";
            result += $"Puzzle Size: {PuzzleSize}\n";
            result += "Base Move List:\n";
            foreach (PuzzleTrigger move in BaseMoveList)
            {
                result += $"- {move}\n";
            }
            result += "Layers:\n";
            for (int layerNumber = 0; layerNumber < GetNumLayers(); layerNumber++)
            {
                TriggerSetLayer layer = Layers[layerNumber];
                result += $"- Layer {layerNumber} : {layer.GetNumberOfTriggers()} triggers\n";
                int layerSize = layer.GetNumberOfTriggers();
                for (int triggerId = 0; triggerId < layerSize; triggerId++)
                {
                    result += $"-- {layer.GetTriggerById(triggerId)}\n";
                }
            }
            return result;
        }
    }
}