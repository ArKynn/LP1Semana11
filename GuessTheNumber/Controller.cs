using System;
using System.Linq;

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
        private bool _isInputValid;

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
        
        private static bool CheckIfType(string? input)
        {
            return input!.All(char.IsDigit);
        }

        private string CheckIfInputValid()
        {
            string? output = View.GetInput();
            if (CheckIfType(output))
            {
                _isInputValid = true;
                return output!;

            }
            View.ShowMessage("Error");
            return "Error:0";
        }

        private string InputValidationLoop()
        {
            string output = "";
            _isInputValid = false;
            while (!_isInputValid)
            {
                string checkOutput = CheckIfInputValid();
                if (checkOutput == "Error:0")
                {
                }
                else
                {
                    output = checkOutput;
                    _isInputValid = true;
                }
            }

            return output;
        }
        
    }
}