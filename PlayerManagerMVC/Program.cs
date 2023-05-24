namespace PlayerManagerMVC;

public class Program
{
    public void Main()
    {
        List<Player> players = new List<Player>();

        Controller controller = new Controller(players);

        View view = new View(players, controller);
    }
}