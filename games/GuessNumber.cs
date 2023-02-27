namespace UGames.games
{
    internal class GuessNumber : IGame
    {
        private readonly int NUM_DIGITS = 3;
        private readonly int MAX_GUESSES = 10;

        private readonly Random rnd;
        private string secretNumber;

        public string Name { get; }
        public string Description { get; }

        public GuessNumber()
        {
            rnd = new Random();
            Name = "Guess Number";
            Description = @"
                In Guess Number game you need guess a secret 3-digit number based on some tips. 
                The game offers one of the following hints in response to your guess: 
                    - “Almost” when your guess has a correct digit in the wrong place, 
                    - “Right” when your guess has a correct digit in the correct place, 
                    - and “No” if your guess has no correct digits. 
                You have 10 tries to guess the secret number. Good luck!
                ";
        }

        public void Play()
        {
            secretNumber = getSecretNumber();
            Console.WriteLine(Name);
            Console.WriteLine(Description);

            while (true)
            {
                Console.WriteLine("Wanna play?! Let's play !");
                Console.WriteLine(string.Format("You have {0} attempts to guess the number.", MAX_GUESSES));

                int guessCount = 1;
                while (guessCount <= MAX_GUESSES)
                {
                    string guess = "";
                    while (guess?.Length != NUM_DIGITS || !int.TryParse(guess, out int guessNum))
                    {
                        Console.WriteLine(string.Format("Guess: {0}", guessCount));
                        guess = Console.ReadLine();
                    }

                    Console.WriteLine(GetTip(guess));
                    guessCount++;

                    if (guess == secretNumber)
                    {
                        break;
                    }

                    if (guessCount > MAX_GUESSES)
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine(string.Format("Answer was {0}", secretNumber));
                    }
                }

                Console.WriteLine("Wanna play again?!");
                var answer = Console.ReadLine();
                if (answer == null || !answer.Contains("y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

            Console.WriteLine("Thanks for this game!");
        }

        private string getSecretNumber()
        {
            int num = 0;
            int d = 1;
            for (int i = 0; i < NUM_DIGITS; i++)
            {
                num += rnd.Next(10) * d;
                d *= 10;
            }
            return num.ToString();
        }

        private string GetTip(string guessNum)
        {
            if (guessNum == secretNumber)
            {
                return "Congrats!";
            }

            var tips = new List<string>();
            for (int i = 0; i < guessNum.Length; i++)
            {
                if (i < secretNumber.Length && guessNum[i] == secretNumber[i])
                {
                    tips.Add("Right");
                }
                else if (secretNumber.Contains(guessNum[i]))
                {
                    tips.Add("Almost");
                }
            }

            if (!tips.Any())
            {
                return "No";
            }

            tips.Sort(); // иначе будет слишком просто

            return string.Join(" ", tips);
        }
    }
}
