using System;

namespace GuessTheNumber
{
    public class Controller
    {
        private int _targetNum;
        private readonly Random _random;
        public Controller(Random random)
        {
            _random = random;
        }

        private int _guess;
        public static int Attempts { get; private set; }
        private bool _guessedCorrectly = false;
        
        public void Run(View view)
        {
            _targetNum = _random.Next(1, 101);
            Attempts = 0;
            
            View.ShowMessage("GreetUser");

            while (!_guessedCorrectly)
            {
                View.ShowMessage("Guess");
            }
        }
        
    }
}