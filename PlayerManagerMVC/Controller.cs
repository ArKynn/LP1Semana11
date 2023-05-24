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
            view.ShowMenu("MainMenu");
            string? option = View.GetInput();

            switch (option)
            {
                case "1":
                    InsertPlayer(_players);
                    break;
                
                case "2":
                    view.ShowMenu("ListPlayerMenu");
                    ListPlayers(_players);
                    break;

                case "0":
                    view.ShowMenu("Farewell");
                    isRunning = false;
                    break;
                default:
                    View.WriteError();
                    break;
            }
            
            // Wait for user to press a key...
            view.ShowMenu("WaitingKeyPress");
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
            switch (CheckIfInputValid(expectedType))
            {
                case "Error:0":
                    break;
                default:
                    output = default!;
                    _isInputValid = true;
                    break;
            }
        }

        return output;
    }

    private static void ListPlayers(List<Player> players)
    {
        // Show each player in the enumerable object
        foreach (Player p in players)
        {
            View.Write($" -> {p.Name} with a score of {p.Score}");
        }
        View.Write("");
    }

    
}