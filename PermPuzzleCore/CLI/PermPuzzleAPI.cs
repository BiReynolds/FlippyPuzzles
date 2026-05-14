namespace PermPuzzleCore.CLI
{
    public class PermPuzzleAPI
    {
        readonly PermPuzzle Puzzle;
        readonly List<string> MoveAliases = new();
        int LastMove;
        string ReactionString = "";
        public PermPuzzleAPI(int puzzleSize, PermPuzzleType puzzleType)
        {
            Puzzle = PermPuzzleFactory.CreatePuzzle(puzzleSize, puzzleType);
            MoveAliases = PermPuzzleFactory.GetPuzzleMoveNames(puzzleSize, puzzleType);
        }

        public string ReceiveAndRespond(string input)
        {
            Receive(input);
            return Respond();
        }

        private void Receive(string input)
        {
            switch (input.ToLower())
            {
                case "reset":
                    Puzzle.Reset();
                    ReactionString = "Puzzle reset";
                    break;
                default:
                    ApplyMove(input);
                    ReactionString = "";
                    break;
            }
        }

        private string Respond()
        {
            return ReactionString;
        }

        private void ApplyMove(string moveAlias)
        {
            int moveIndex = MoveAliases.IndexOf(moveAlias);
            if (moveIndex == -1)
            {
                Console.WriteLine($"{moveAlias} is not a valid command or move...");
                return;
            }
            Puzzle.ApplyMove(moveIndex);
        }

        public int[] GetPuzzleState()
        {
            return Puzzle.GetState();
        }
    }
}