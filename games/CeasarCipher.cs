using System.Text;

namespace Unilecs.Games
{
    internal class CeasarCipher
    {
        private const string SYMBOLS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string Name = "Ceasar Cipher";
        public readonly string Description = string.Format(@"
                The Caesar cipher encrypts letters by shifting them over by a key number. 
                For example, a key of 2 means the letter A is encrypted into C, the letter B encrypted into D, and so on.");

        class CeasarParams
        {
            public string Mode = "";
            public int Key;
            public string Message = "";
        }

        public void Play()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);

            while(true)
            {
                Console.WriteLine("\nLet's play !");
                CeasarParams? input = getParams();
                if (input != null)
                {
                    Console.WriteLine(processCeasarCipher(input.Message, input.Key, input.Mode));
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

        private string processCeasarCipher(string input, int key, string mode)
        {
            var result = new StringBuilder();
            foreach (char sym in input)
            {
                if (SYMBOLS.Contains(sym))
                {
                    int num = SYMBOLS.IndexOf(sym);
                    num = mode == "encrypt" ? num + key : num - key;

                    if (num >= SYMBOLS.Length)
                    {
                        num -= SYMBOLS.Length;
                    }
                    else if (num < 0)
                    {
                        num += SYMBOLS.Length;
                    }

                    result.Append(SYMBOLS[num]);
                }
                else
                {
                    result.Append(sym);
                }
            }

            return result.ToString();
        }

        private CeasarParams? getParams()
        {
            Console.WriteLine("Enter the Encrypt (e) or Decrypt (d) mode?");
            string mode = Console.ReadLine();
            if (string.IsNullOrEmpty(mode) || !(mode.StartsWith("e") || mode.StartsWith("d")))
            {
                Console.WriteLine("Please enter the letter 'e' or 'd'.");
                return null;
            }

            mode = mode.StartsWith("e") ? "encrypt" : "decrypt";

            Console.WriteLine(string.Format("Please enter the key (0 to {0}) to use.", SYMBOLS.Length - 1));
            string key = Console.ReadLine();
            bool isNum = int.TryParse(key, out int keyVal);
            if (!isNum || keyVal < 0 || keyVal > SYMBOLS.Length - 1)
            {
                Console.WriteLine("Please enter the correct key.");
                return null;
            }

            Console.WriteLine(string.Format("Please enter the message to {0}.", mode));
            string message = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return new CeasarParams
            {
                Mode = mode,
                Key = keyVal,
                Message = message
            };
        }
    }
}
