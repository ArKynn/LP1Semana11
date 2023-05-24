namespace PlayerManagerMVC;

public class Program
{
    public static void Main()
    {
        List<Player> players = new List<Player>();

        Controller controller = new Controller(players);

        View view = new View(players, controller);

        controller.Run(view);
    }
}