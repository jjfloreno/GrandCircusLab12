using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_RockPaperScissors
{
    class HumanPlayer : Player
    {
        public string Name { get; set; }
        public override Roshambo generateRoshambo()
        {
          
            return Validator.CheckIsRoshambo("Please enter the name or number");
            
        }
    }
}
