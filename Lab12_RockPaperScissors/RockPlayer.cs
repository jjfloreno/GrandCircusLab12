using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_RockPaperScissors
{
    class RockPlayer : Player
    {
        public override Roshambo generateRoshambo()
        {
            return Roshambo.rock;
        }
    }
}
