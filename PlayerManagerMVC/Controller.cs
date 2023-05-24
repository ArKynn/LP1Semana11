namespace PlayerManagerMVC;

public class Controller
{
    private List<Player> _players;
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
                    view.ShowMenu("InsertPlayerMenu");
                    InsertPlayer(_players);
                    break;
                
                case "2":
                    view.ShowMenu("ListPlayerMenu");
                    break;
                
                case "0":
                    View.Write("Bye");
                    isRunning = false;
                    break;
                default:
                    View.WriteError();
                    break;
            }
            
            // Wait for user to press a key...
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }
    }

    private void InsertPlayer(List<Player> players)
    {
        bool isInputValid = false;
        string? name = "";
        int score = 0;
        while (!isInputValid)
        {
            View.Write("Name: ");
            string? newname = View.GetInput();
            
            if (CheckIfType(typeof(string), newname))
            {
                name = newname;
                isInputValid = true;
            }
            else
            {
                View.WriteError();
            }
        }

        isInputValid = false;
        while (!isInputValid)
        {
            View.Write("Score: ");
            string? newscore = View.GetInput();
            
            if (CheckIfType(typeof(int), newscore))
            {
                score = Convert.ToInt16(newscore);
                isInputValid = true;
            }
            else
            {
                View.WriteError();
            }
        }
        
        Player newPlayer = new Player(name, score);
        players.Add(newPlayer);
    }
    public static bool CheckIfType(Type type, string? input)
    {
        if (type == typeof(int)) return input!.All(char.IsDigit);
        if (type == typeof(string)) return input!.All(char.IsLetter);
        return false;
    }
    
}