using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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
        private bool _isGuessValid;

        public void Run(View view)
        {
            _targetNum = _random.Next(1, 101);
            Attempts = 0;
            
            View.ShowMessage("GreetUser");

            while (!_guessedCorrectly)
            {
                _isGuessValid = false;
                while (!_isGuessValid)
                {
                    View.ShowMessage("Guess");
                    int unverifiedGuess = Convert.ToInt16(InputValidationLoop());
                    if (unverifiedGuess > 0 && unverifiedGuess < 101)
                    {
                        _guess = unverifiedGuess;
                        Attempts++;
                        _isGuessValid = true;
                    }
                    else
                    {
                        View.ShowMessage("Error");
                    }
                    
                }
                
                if (_guess == _targetNum)
                {
                    View.ShowMessage("CorrectGuess");
                    _guessedCorrectly = true;
                }
                else if (_guess > _targetNum)
                {
                    View.ShowMessage("HighGuess");
                }
                else if (_guess < _targetNum)
                {
                    View.ShowMessage("LowGuess");
                }
            }
            View.ShowMessage("Thanks");
        }
        
        private static bool CheckIfType(string input)
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
                    View.ShowMessage("Guess");
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