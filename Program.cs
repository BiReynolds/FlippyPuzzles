using PermPuzzleCore;
using PermPuzzleCore.CLI;
using PermPuzzleCore.Tests;

public static class Program {
	public static void Main()
	{
		PermPuzzleCoreCLI cli = new(5, PermPuzzleType.ShiftAndSwap);
		cli.Start();
	}
}
