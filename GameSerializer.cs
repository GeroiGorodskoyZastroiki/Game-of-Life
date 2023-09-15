using System.Drawing;
using AnimatedGif;

public class GameSerializer
{
    Game _game;
    AnimatedGifCreator _gif;

    public GameSerializer(Game game)
    {
        _game = game;
        _gif = AnimatedGif.AnimatedGif.Create("Life.gif", 200); //создаём GIF файл
    }

    public void AddFrame (bool [,] arr) //добавляет кадр в созданный GIF
    {
        var img = new Bitmap(_game.Width, _game.Height);
        for (int i = 0; i < _game.Width; i++)
            for (int j = 0; j < _game.Height; j++)
                img.SetPixel(i, j, arr[i,j] ? Color.Black : Color.White);
        _gif.AddFrame(img, quality: GifQuality.Bit4);
    }
}