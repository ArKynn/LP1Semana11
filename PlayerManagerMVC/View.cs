namespace PlayerManagerMVC;

public class View
{
    private List<Player> _players;
    public View(List<Player> players, Controller controller)
    {
        _players = players;
    }
    
    public static void ShowMenu(string menuName)
    {
        switch (menuName)
        {
            case "MainMenu":
                Console.WriteLine("Menu");
                Console.WriteLine("----\n");
                Console.WriteLine("1. Insert player");
                Console.WriteLine("2. List all players");
                Console.WriteLine("3. List players with score greater than");
                Console.WriteLine("4. Sort players");
                Console.WriteLine("0. Quit\n");
                Console.Write("Your choice > ");
                break;
            
            case "ListPlayerMenu":
                Console.WriteLine("\nList of players");
                Console.WriteLine("-------------\n");
                break;

            case "Farewell":
                Console.WriteLine("Bye!");
                break;
            case "WaitingKeyPress":
                Console.Write("\nPress any key to continue...\n");
                break;
        }
    }
    
    public static string? GetInput()
    {
        return Console.ReadLine();
    }

    public static void Write(string message)
    {
        Console.WriteLine(message);
    }
    
    public static void WriteError()
    {
        Console.Error.WriteLine("\n>>> Invalid Input Type or Value <<<\n");
    }
}