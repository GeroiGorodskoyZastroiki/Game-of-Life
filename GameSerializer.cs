using System.Drawing;
using AnimatedGif;

public class GameSerializer
{
    Game _game;
    AnimatedGifCreator _gif;

    public GameSerializer()
    {
        _game = new Game();
        _gif = AnimatedGif.AnimatedGif.Create("game.gif", 33);
        _game.
    }

    void AddFrame (bool [,] arr)
    {
        var img = new Bitmap(_game.Width, _game.Height);
        _gif.AddFrame(img, delay: -1, quality: GifQuality.Bit8);
    }
}