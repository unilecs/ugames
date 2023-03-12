using System;
using System.Collections.Generic;
using System.Text;

namespace Unilecs.Games
{
    internal class GuessNumber
    {
        private const uint NUM_DIGITS = 3;
        private const uint MAX_GUESSES = 10;

        public const string Name = "Guess Number";
        public readonly string Description = string.Format(@"
                In Guess Number game you need guess a secret 3-digit number based on some tips. 
                The game offers one of the following hints in response to your guess: 
                    - a combination of “N Almost” when your guess has N > 0 correct digit on wrong places
                    and  “M Right” when your guess has M > 0 correct digit on the correct places, 
                    - or “No” if your guess has no correct digits. 
                You have {0} tries to guess the secret number. Good luck!", MAX_GUESSES);

        struct MatchResult
        {
            public uint StrictMatches;
            public uint WeakMatches;
        }

        public void Play()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);

            while (true)
            {
                Console.WriteLine("\nWanna play?! Let's play !");
                Console.WriteLine($"You have {MAX_GUESSES} attempts to guess the number.");

                string secret = makeSecretNumber();
                int guessCount = 1;
                while (guessCount <= MAX_GUESSES)
                {
                    string guess = "";
                    while (guess?.Length != NUM_DIGITS || !int.TryParse(guess, out int guessNum))
                    {
                        Console.WriteLine($"Enter guess {guessCount}:");
                        guess = Console.ReadLine();
                    }

                    Console.WriteLine(GetTip(secret, guess));

                    if (guess == secret)
                    {
                        break;
                    }

                    if (++guessCount > MAX_GUESSES)
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Answer was {secret}");
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

        private static string makeSecretNumber()
        {
            var rnd = new Random();
            var sb = new StringBuilder();
            for (var i = 0u; i < NUM_DIGITS; ++i)
            {
                sb.Append((char)(0x30 + rnd.Next(10)));
            }
            return sb.ToString();
        }

        private static MatchResult MatchGuess(string secret, string guess)
        {
            var result = new MatchResult();
            for (var i = 0; i < Math.Min(guess.Length, secret.Length); ++i)
            {
                if (guess[i] == secret[i])
                {
                    ++result.StrictMatches;
                    continue;
                }
                if (secret.Contains(guess[i]))
                {
                    ++result.WeakMatches;
                }
            }
			return result;
        }

        private static string GetTip(string secret, string guess)
        {
            var result = MatchGuess(secret, guess);
            if (result.StrictMatches == secret.Length)
            {
                return "Congrats!";
            }

            var tips = new List<string>();
            if (result.StrictMatches > 0)
            {
                tips.Add($"{result.StrictMatches} Right");
            }
            if (result.WeakMatches > 0)
            {
                tips.Add($"{result.WeakMatches} Almost");
            }

            if (tips.Count == 0)
            {
                return "No";
            }

            return string.Join(" ", tips);
        }
    }
}
