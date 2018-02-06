using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_RockPaperScissors
{
    class ThirdPlayer:Player
    {
        private static Random random = new Random();
        public List<RoshamboCount> PlayerChoices { get; set; }
        public Roshambo CounterPlayer { get; set; }


        public ThirdPlayer()
        {
            PlayerChoices = new List<RoshamboCount>
            {
                new RoshamboCount(Roshambo.rock),
                new RoshamboCount(Roshambo.paper),
                new RoshamboCount(Roshambo.scissor)
            };
        }

        public override Roshambo generateRoshambo()
        {
            // start off as random, as user choice list grows larger than lets say 3
            // we start picking an option based on the user choice
            // for example, if user picks paper three times in a row
            // do a random between 1 - 6, however, the last 3 numbers will 
            // be scissors. 
            int newRnd;
            int choice = PlayerChoices.Sum(x => x.Occurrences);
            if (choice >= 4)
            {
                AdjustChoices();
                newRnd = random.Next(1, 6);

                if (choice > 3)
                {
                    return CounterPlayer;
                }
                newRnd = random.Next(1, 3);
                return (Roshambo)choice;
            }
            newRnd = random.Next(1, 3);
            return (Roshambo)choice;
        }

        private void AdjustChoices()
        {
            var mostOccurrences = PlayerChoices.OrderByDescending(choice => choice.Occurrences).ToList();
            CounterPlayer = mostOccurrences[0].Choice;
        }

    }
}
