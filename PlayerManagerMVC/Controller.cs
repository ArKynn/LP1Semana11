namespace PlayerManagerMVC;

public class Controller
{
    private readonly List<Player> _players;
    private bool _isInputValid;
    public Controller(List<Player> players)
    {
        _players = players;
    }

    public void Run(View view)
    {
        bool isRunning = true;
        
        while (isRunning)
        {
            View.ShowMenu("MainMenu");
            string? option = View.GetInput();

            switch (option)
            {
                case "1":
                    InsertPlayer(_players);
                    break;
                
                case "2":
                    View.ShowMenu("ListPlayerMenu");
                    ListPlayers(_players);
                    break;
                
                case "3":
                    IEnumerable<Player> playersWithGreaterScore = FindPlayersWithGreaterScoreThan(_players);
                    ListPlayers(playersWithGreaterScore);
                    break;
                
                case "0":
                    View.ShowMenu("Farewell");
                    isRunning = false;
                    break;
                default:
                    View.WriteError();
                    break;
            }
            
            // Wait for user to press a key...
            View.ShowMenu("WaitingKeyPress");
            Console.ReadKey(true);
        }
    }

    private void InsertPlayer(List<Player> players)
    {
        var name = InputValidationLoop("Name: ", typeof(string));
        int score = Convert.ToInt16(InputValidationLoop("Score :", typeof(int)));

        Player newPlayer = new Player(name, score);
        players.Add(newPlayer);
    }
    private static bool CheckIfType(Type type, string? input)
    {
        if (type == typeof(int)) return input!.All(char.IsDigit);
        return type == typeof(string) && input!.All(char.IsLetter);
    }

    private string CheckIfInputValid(Type expectedType)
    {
        string? output = View.GetInput();
        if (CheckIfType(expectedType, output))
        {
            _isInputValid = true;
            return output!;

        }
        View.WriteError();
        return "Error:0";
    }

    private string InputValidationLoop(string messageToDisplay, Type expectedType)
    {
        string output = "";
        _isInputValid = false;
        while (!_isInputValid)
        {
            View.Write(messageToDisplay);

            string checkOutput = CheckIfInputValid(expectedType);
            if (checkOutput == "Error:0")
            {
            }
            else
            {
                output = checkOutput;
                _isInputValid = true;
            }
        }

        return output;
    }

    private static void ListPlayers(IEnumerable<Player> players)
    {
        // Show each player in the enumerable object
        foreach (Player p in players)
        {
            View.Write($" -> {p.Name} with a score of {p.Score}");
        }
        View.Write("");
    }
    
    private IEnumerable<Player> FindPlayersWithGreaterScoreThan(List<Player> players)
    {
        int minScore = Convert.ToInt32(InputValidationLoop("\nMinimum score player should have?", typeof(int)));
        // Cycle all players in the original player list
        foreach (Player p in players)
        {
            // If the current player has a score higher than the
            // given value....
            if (p.Score > minScore)
            {
                // ...return him as a member of the player enumerable
                yield return p;
            }
        }
    }




    
}