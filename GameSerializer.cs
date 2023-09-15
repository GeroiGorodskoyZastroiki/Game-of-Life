using System.Drawing;
using AnimatedGif;

public class GameSerializer
{
    Game _game;
    AnimatedGifCreator _gif;

    public GameSerializer(Game game)
    {
        _game = game;
        //создаём GIF файл с задержкой между кадрами для удобного просмотра
        _gif = AnimatedGif.AnimatedGif.Create("Life.gif", 200); 
    }

    public void AddFrame (bool [,] arr) //добавляем кадр в созданный GIF
    {
        //создаём кадр
        var img = new Bitmap(_game.Width, _game.Height);
        for (int i = 0; i < _game.Width; i++)
            for (int j = 0; j < _game.Height; j++)
                img.SetPixel(i, j, arr[i,j] ? Color.Black : Color.White);
        //добавляем кадр в созданный GIF
        _gif.AddFrame(img, quality: GifQuality.Bit4);
    }
}

