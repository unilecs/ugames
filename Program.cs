using System;
using Unilecs.Games;

public class Program
{
	public static void Main()
    {
        Console.WriteLine("U Games");
        CeasarHackerGame();
    }

    static void GuessNumberGame()
    {
        var guessNumber = new GuessNumber();
        guessNumber.Play();
    }

    static void BitMapGame()
    {
        var bitmap = new Bitmap();
        bitmap.Play();
    }

    static void CeasarCipherGame()
    {
        var cc = new CeasarCipher();
        cc.Play();
    }

    static void CeasarHackerGame()
    {
        var cc = new CeasarHacker();
        cc.Play();
    }
}
