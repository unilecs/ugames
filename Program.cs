﻿using System;
using Unilecs.Games;

public class Program
{
	public static void Main()
    {
        Console.WriteLine("U Games");
        BitMapGame();
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
}
