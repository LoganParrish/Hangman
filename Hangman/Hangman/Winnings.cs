using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Winnings
    {
        public bool KeepGoing { get; set; }
        public int Wins { get; set; }

        public Winnings(int wins)
        {
            this.KeepGoing = true;
            this.Wins = 0;
        }
        
    }
}
