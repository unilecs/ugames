using UGames.games;

Console.WriteLine("U Games");
TestGame();


static void TestGame()
{
    var guessNumber = new GuessNumber();
    guessNumber.Play();
}
