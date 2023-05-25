using System;

namespace GuessTheNumber
{
    public class Controller
    {
        private int _targetNum;
        public Controller(Random random)
        {
            _targetNum = random.Next(1, 101);
        }

        public static void Run(View view)
        {
            
        }
        
    }
}