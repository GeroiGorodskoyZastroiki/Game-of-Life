public class Game
{
    int Iterations;
    public int Width  { get; private set; }
    public int Height { get; private set; }
    bool [,] _currentState;
    bool [,] _nextState;
    GameSerializer _gameSerializer;
    Random rnd = new Random();

    public Game(int width, int height, int iterations)
    {
        Width = width;
        Height = height;
        Iterations = iterations;
        _currentState = new bool [Width,Height];
        _nextState = new bool [Width,Height];
        _gameSerializer = new GameSerializer(this);
        Init();
    }

    void Init() //инициализирует массив случайными значениями
    {
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                _currentState[i,j] = rnd.Next(2) == 1;
    }

    public void PlayGame() //запускает цикл из n итераций
    {
        for (int i = 0; i < Iterations; i++)
            _gameSerializer.AddFrame(CalcNextState());
    }

    bool[,] CalcNextState() //рассчитывает следующее состояние поля
    {
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
            {
                if (!_currentState[i,j]) continue;
                byte diagonalNeighboursCount = 0;
                if (PositionIsValid(i-1, j-1))
                    if (_currentState[i-1, j-1]) diagonalNeighboursCount++;
                if (PositionIsValid(i-1, j+1))
                    if (_currentState[i-1, j+1]) diagonalNeighboursCount++;
                if (PositionIsValid(i+1, j-1))
                    if (_currentState[i+1, j-1]) diagonalNeighboursCount++;
                if (PositionIsValid(i+1, j+1))
                    if (_currentState[i+1, j+1]) diagonalNeighboursCount++;
                if (diagonalNeighboursCount >= 2) _nextState[i,j] = true;
                else _nextState[i,j] = false;
            }
        _currentState = _nextState;
        return _nextState;
    }

    bool PositionIsValid(int i, int j) //проверяет: существует индекс или нет
    {
        return ((i < 0 || i > Width-1) || (j < 0 || j > Height-1)) ? false : true;
    }
}