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
            string? option = view.GetInput();

            switch (option)
            {
                
                case "0":
                    View.Write("Bye");
                    isRunning = false;
                    break;
                default:
                    Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                    break;
            }
        }
    }
    
}