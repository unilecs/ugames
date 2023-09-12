using System.Text;

namespace Unilecs.Games
{
    internal class CeasarHacker
    {
        private const string SYMBOLS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string Name = "Ceasar Hacker";
        public readonly string Description = string.Format(@"
                The Caesar Hacker can hack messages encrypted with the Caesar cipher, even if you don’t know the key. 
                There are only 26 possible keys for the Caesar cipher, so a algorithm can easily try all possible decryptions and display the results.");


        public void Play()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);

            while (true)
            {
                Console.WriteLine("\nLet's play !");

                Console.WriteLine("Enter the encypted chipher message");
                string encypted = Console.ReadLine();
                if (!string.IsNullOrEmpty(encypted))
                {
                    processCeasarHacker(encypted.ToUpper());
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


        private void processCeasarHacker(string input)
        {
            for (int i = 1; i <= SYMBOLS.Length; i++)
            {
                var decrypted = new StringBuilder();
                foreach (char sym in input)
                {
                    if (SYMBOLS.Contains(sym))
                    {
                        int num = SYMBOLS.IndexOf(sym) - i;

                        if (num < 0)
                            num += SYMBOLS.Length;

                        decrypted.Append(SYMBOLS[num]);
                    }
                    else
                    {
                        decrypted.Append(sym);
                    }
                }

                Console.WriteLine(string.Format("Key {0}: {1}", i, decrypted));
            }
        }
    }
}
