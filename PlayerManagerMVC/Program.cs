namespace PlayerManagerMVC;

public class Program
{
    public static void Main()
    {
        List<Player> players = new List<Player>() {
            new Player("Best player ever", 100),
            new Player("An even better player", 500)
        };

        Controller controller = new Controller(players);

        View view = new View(players, controller);

        controller.Run(view);
    }
}