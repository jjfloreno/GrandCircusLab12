using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_RockPaperScissors
{
    class RoshamboCount
    {
        public Roshambo Choice {set;get;}
        public int Occurrences { get; set; } = 0;

        public RoshamboCount(Roshambo _choice)
        {
            Choice = _choice;
        }

    }
}
