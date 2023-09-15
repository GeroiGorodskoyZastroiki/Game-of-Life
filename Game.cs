public class Game
{
    const int Iters = 1000;
    public const int Width = 100;
    public const int Height = 100;
    bool [,] _currentState = new bool [Width,Height];
    bool [,] _nextState = new bool [Width,Height];
    Random rnd = new Random();

    void Init()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                _currentState[i,j] = rnd.Next(2) == 1;
            }
        }
    }

    public void StartGame()
    {
        for (int i = 0; i < Iters; i++)
            CalcNextState();
    }

    bool[,] CalcNextState()
    {

        return _nextState;
    }
}