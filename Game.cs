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

    void Init() //инициализируем массив случайными значениями
    {
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                _currentState[i,j] = rnd.Next(2) == 1;
    }

    public void PlayGame() //запускаем цикл из n итераций
    {
        for (int i = 0; i < Iterations; i++)
            //изменяем состояние и записываем результат
            _gameSerializer.AddFrame(CalcNextState());
    }

    bool[,] CalcNextState() //рассчитываем следующее состояние поля
    {
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
            {
                //если сама клетка мёртвая, то пропускаем итерацию
                if (!_currentState[i,j]) continue;
                byte diagonalNeighboursCount = 0;
                //проверяем всех соседей
                if (PositionIsValid(i-1, j-1))
                    if (_currentState[i-1, j-1]) diagonalNeighboursCount++;
                if (PositionIsValid(i-1, j+1))
                    if (_currentState[i-1, j+1]) diagonalNeighboursCount++;
                if (PositionIsValid(i+1, j-1))
                    if (_currentState[i+1, j-1]) diagonalNeighboursCount++;
                if (PositionIsValid(i+1, j+1))
                    if (_currentState[i+1, j+1]) diagonalNeighboursCount++;
                //если есть как минимум 2 живых соседа, то клетка живёт
                if (diagonalNeighboursCount >= 2) _nextState[i,j] = true;
                //иначе умирает
                else _nextState[i,j] = false;
            }
        //обновляем текущее состояние
        _currentState = _nextState;
        return _nextState;
    }

    bool PositionIsValid(int i, int j) =>
        //проверяет, выходит ли индекс за границы массива
        ((i < 0 || i > Width-1) || (j < 0 || j > Height-1)) ? false : true;
}

