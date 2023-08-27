using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unilecs.Games
{
    internal class Bitmap
    {
        private const string Map =
@"
....................................................................
   **************   *  *** **  *      ******************************
  ********************* ** ** *  * ****************************** *
 **      *****************       ******************************
          *************          **  * **** ** ************** *
           *********            *******   **************** * *
            ********           ***************************  *
   *        * **** ***         *************** ******  ** *
               ****  *         ***************   *** ***  *
                 ******         *************    **   **  *
                 ********        *************    *  ** ***
                   ********         ********          * *** ****
                   *********         ******  *        **** ** * **
                   *********         ****** * *           *** *   *
                     ******          ***** **             *****   *
                     *****            **** *            ********
                    *****             ****              *********
                    ****              **                 *******   *
                    ***                                       *    *
                    **     *                    *
....................................................................
";

        public const string Name = "BitMap";
        public const string Description = "BitMap Game";

        public void Play()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);

            while (true)
            {
                Console.WriteLine("\nWanna play?! Let's play !");
                Console.WriteLine("Enter the message to display with the bitmap.");

                string message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message))
                {
                    for (int i = 0; i < Map.Length; i++)
                    {
                        if (Map[i] != '*')
                        {
                            Console.Write(Map[i]);
                        }
                        else
                        {
                            Console.Write(message[i % message.Length]);
                        }
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
    }
}
