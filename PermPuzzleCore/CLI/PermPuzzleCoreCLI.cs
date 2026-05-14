using PermPuzzleCore;

namespace PermPuzzleCore.CLI
{
    public class PermPuzzleCoreCLI
    {
        bool Running = true;
        PermPuzzleAPI PermPuzzleAPI;
        public PermPuzzleCoreCLI(int puzzleSize, PermPuzzleType puzzleType)
        {
            PermPuzzleAPI = new(puzzleSize, puzzleType);
        }
        public void Start()
        {
            Running = true;
            while (Running)
            {
                Loop();
            }
            Exit();
        }
        
        private void Loop()
        {
            string? userInput = Console.ReadLine();
            if (userInput == null)
            {
                return;
            }
            else if (userInput.ToLower() == "exit")
            {
                Running = false;
                return;
            }
            else
            {
                string response = PermPuzzleAPI.ReceiveAndRespond(userInput);
                if (response.Length > 0)
                {
                    Console.WriteLine(response);
                }
                Console.WriteLine(PermHelper.PermToString(PermPuzzleAPI.GetPuzzleState()));
            }
        }

        private void Exit()
        {
            Console.WriteLine("exiting program");
        }
    }
}