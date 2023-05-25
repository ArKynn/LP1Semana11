using System;

namespace GuessTheNumber
{
    public class Program
    {
        public static void Main()
        {
            Random random = new Random();

            Controller controller = new Controller(random);

            View view = new View(random, controller);

            controller.Run(view);
        }
    }
}