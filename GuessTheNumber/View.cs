using System;

namespace GuessTheNumber
{
    public class View
    {
        public View(Random random, Controller controller)
        {
            
        }
        
        public static void ShowMessage(string name)
        {
            switch (name)
            {
                case "GreetUser":
                    Console.WriteLine("Welcome to Guess the Number!");
                    Console.WriteLine("I have chosen a number between 1 and 100.");
                    break;
                
                case "Guess":
                    Console.Write("Take a guess: ");
                    break;
                
                case "LowGuess":
                    Console.WriteLine("Too low! Try again.");
                    break;
                
                case "HighGuess":
                    Console.WriteLine("Too high! Try again.");
                    break;
                
                case "CorrectGuess":
                    Console.WriteLine(
                        "Congratulations! You guessed the number correctly!");
                    Console.WriteLine("Number of attempts: " + Controller.Attempts);
                    break;
                
                case "Error":
                    Console.WriteLine("Error: Invalid input type or value!");
                    break;
                
                case "Thanks":
                    Console.WriteLine("Thank you for playing Guess the Number!");
                    break;
            }
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}