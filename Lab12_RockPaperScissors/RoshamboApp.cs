using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_RockPaperScissors
{
    class RoshamboApp
    {
        public HumanPlayer HumanPlayer { get; set; }
        public Player RockPlayer { get; set; }
        public ThirdPlayer ThirdPlayer { get; set; }
        public bool IsPlaying { get; set; } = true;
        public ConsoleKey Answer { get; set; }
        public int PlayerScore { get; set; } = 0;
        public int AiScore { get; set; } = 0;

        public RoshamboApp()
        {
            HumanPlayer = new HumanPlayer();
            RockPlayer = new RockPlayer();
            ThirdPlayer = new ThirdPlayer();
        }

        public void StartApp()
        {
            Console.WriteLine("Welcome to the Grand Circus rock, paper, scissors thunderdome!");

            HumanPlayer.Name = Validator.CheckName("Please enter your name: ");

            while (IsPlaying)
            {
                Answer = Validator.OneorTwo("Press [1] to face an easy opponent, [2] for a hard opponent: ");
                Console.WriteLine();

                if (Answer == ConsoleKey.D1)
                {
                    PlayAgainstRock();
                }
                else
                {
                    PlayAgainstThird();
                }
                KeepPlaying();
            }
        }

        private void PrintMenu()
        {
            Console.Clear();
            IEnumerable<Roshambo> menu = Enum.GetValues(typeof(Roshambo)).Cast<Roshambo>();

            foreach(Roshambo choice in menu)
            {
                Console.WriteLine($"{(int)choice}. {choice}");
            }
        }

        private void PlayAgainstRock()
        {
            PrintMenu();
            Roshambo input = HumanPlayer.generateRoshambo();
            Roshambo aiInput = RockPlayer.generateRoshambo();


            if (input == RockPlayer.generateRoshambo())
            {
                //tie
                Console.WriteLine("tie!");
            }
            else if (input == Roshambo.paper)
            {
                //paper beats rock, human +1
                Console.WriteLine($"{HumanPlayer.Name} wins!");
                PlayerScore++;
            }
            else
            {
                //rock beats human, rock +1
                Console.WriteLine("Rock wins!");
                AiScore++;
            }
            Console.WriteLine($"{HumanPlayer.Name}: {input}");
            Console.WriteLine($"Ai: {aiInput}");
            Console.WriteLine($"Scoreboard: {HumanPlayer.Name}: {PlayerScore} / Ai: {AiScore}");
            int index = ThirdPlayer.PlayerChoices.FindIndex(x => x.Choice == input);
            ThirdPlayer.PlayerChoices[index].Occurrences++;
        }

        private void PlayAgainstThird()
        {
            PrintMenu();
            Roshambo input = HumanPlayer.generateRoshambo();
            Roshambo aiInput = ThirdPlayer.generateRoshambo();

            if (input == aiInput)
            {
                //tie
                Console.WriteLine("tie!");
            }
            else if ((input == Roshambo.paper && aiInput == Roshambo.rock)
                || (input == Roshambo.rock && aiInput == Roshambo.scissor)
                || (input == Roshambo.scissor && aiInput == Roshambo.paper))
            {
                //paper beats rock, human +1
                Console.WriteLine($"{HumanPlayer.Name} wins!");
                PlayerScore++;
            }
            else
            {
                //rock beats human, rock +1
                Console.WriteLine("AI wins!");
                AiScore++;
            }
            Console.WriteLine($"{HumanPlayer.Name}: {input}");
            Console.WriteLine($"Ai: {aiInput}");
            Console.WriteLine($"Scoreboard: {HumanPlayer.Name}: {PlayerScore} / Ai: {AiScore}");
            int index = ThirdPlayer.PlayerChoices.FindIndex(x => x.Choice == input);
            ThirdPlayer.PlayerChoices[index].Occurrences++;
        }

        private void KeepPlaying()
        {
            Answer = Validator.YesOrNo("Do you want to keep playing? <Y to continue, N to exit>");
            if (Answer == ConsoleKey.Y)
            {
                Console.Clear();
            }
            else if (Answer == ConsoleKey.N)
            {
                IsPlaying = false;
            }
        }
    }
}
