using System;
using Unilecs.Games;

public class Program
{
	public static void Main()
    {
        Console.WriteLine("U Games");
        GuessNumberGame();
    }

    static void GuessNumberGame()
    {
        var guessNumber = new GuessNumber();
        guessNumber.Play();
    }
}
