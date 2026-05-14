using System.Diagnostics;

namespace PermPuzzleCore.Tests
{
    public static class TriggerSetTests
    {
        static readonly int[] ShiftAndFlipLayerSizes = [1, 2, 3, 5, 8, 12, 15, 20, 22, 19, 11, 2];
        public static void ZeroLayerTest(bool verbose = false)
        {
            TriggerSet testSet = new([new PuzzleTrigger(5)], 0);
            if (verbose)
            {
                Console.WriteLine("Running ZeroLayerTest with the following TriggerSet:");
                Console.WriteLine(testSet);
            }
            Debug.Assert(testSet.GetNumLayers() == 1, $"ZeroLayerTest failed - Expected 1 layer but measured {testSet.GetNumLayers()}");
            Debug.Assert(testSet.GetNumTriggers() == 1, $"ZeroLayerTest failed - Expected 1 trigger but measured {testSet.GetNumTriggers()}");
            if (verbose)
            {
                Console.WriteLine("ZeroLayerTest passed");
            }
        }

        public static void SimpleShiftTest(bool verbose = false)
        {
            PuzzleTrigger trigger = new(PermHelper.CreateShiftPerm(5));
            TriggerSet testSet = new([trigger], 5);
            if (verbose)
            {
                Console.WriteLine("Running SimpleShiftTest with the following TriggerSet:");
                Console.WriteLine(testSet);
            }
            Debug.Assert(testSet.GetNumLayers() == 6, $"SimpleShiftTest failed - Expected 6 layers but measured {testSet.GetNumLayers()}");
            Debug.Assert(testSet.GetNumTriggers() == 5, $"SimpleShiftTest failed - Expected 5 triggers but measured {testSet.GetNumTriggers()}");
            for (int layerNum = 0; layerNum < 4; layerNum++)
            {
                TriggerSetLayer layer = testSet.Layers[layerNum];
                Debug.Assert(layer.GetNumberOfTriggers() == 1, $"SimpleShiftTest failed - Expected layer {layerNum} to have 1 trigger but measured {layer.GetNumberOfTriggers()}");
            }
            Debug.Assert(testSet.Layers[5].GetNumberOfTriggers() == 0, $"SimpleShiftTest failed - Expected layer 5 to have 0 triggers but measured {testSet.Layers[5].GetNumberOfTriggers()}");
            if (verbose)
            {
                Console.WriteLine("SimpleShiftTest passed");
            }
        }

        public static void ShiftAndFlipTest(bool verbose = false)
        {
            PuzzleTrigger move0 = new(PermHelper.CreateShiftPerm(5));
            PuzzleTrigger move1 = new(PermHelper.CreateFlipPerm(5, 0));
            TriggerSet testSet = new([move0, move1], 15);
            if (verbose)
            {
                Console.WriteLine("Running ShiftAndFlipTest with the following TriggerSet:");
                Console.WriteLine(testSet);
            }
            Debug.Assert(testSet.GetNumLayers() == 12, $"ShiftAndFlipTest failed - Expected 12 layers but measured {testSet.GetNumLayers}");
            Debug.Assert(testSet.GetNumTriggers() == 120, $"ShiftAndFlipTest failed - Expected 120 triggers but measured {testSet.GetNumTriggers()}");
            for (int i = 0; i < ShiftAndFlipLayerSizes.Length; i++)
            {
                int expectedSize = ShiftAndFlipLayerSizes[i];
                int measuredSize = testSet.Layers[i].GetNumberOfTriggers();
                Debug.Assert(measuredSize == expectedSize, $"ShiftAndFlipTest failed - Expected Layer {i} to have {ShiftAndFlipLayerSizes[i]} trigger(s), but measured {measuredSize}");
            }
            if (verbose)
            {
                Console.WriteLine("ShiftAndFlipTest passed");
            }
        }
    }
}