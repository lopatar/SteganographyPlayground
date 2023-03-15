namespace SteganographyPlayground;

internal sealed class ImageFile
{
    private static readonly Dictionary<char, Bgr24> CharColors = new()
    {
        { 'a', new Bgr24(255, 255, 255) },
        { 'b', new Bgr24(245, 255, 255) },
        { 'c', new Bgr24(235, 255, 255) },
        { 'd', new Bgr24(225, 255, 255) },
        { 'e', new Bgr24(215, 255, 255) },
        { 'f', new Bgr24(205, 255, 255) },
        { 'g', new Bgr24(195, 255, 255) },
        { 'h', new Bgr24(255, 245, 255) },
        { 'i', new Bgr24(255, 235, 255) },
        { 'j', new Bgr24(255, 225, 255) },
        { 'k', new Bgr24(255, 215, 255) },
        { 'l', new Bgr24(255, 205, 255) },
        { 'm', new Bgr24(255, 195, 255) },
        { 'n', new Bgr24(255, 255, 245) },
        { 'o', new Bgr24(255, 255, 235) },
        { 'p', new Bgr24(255, 255, 225) },
        { 'q', new Bgr24(255, 255, 215) },
        { 'r', new Bgr24(255, 255, 205) },
        { 's', new Bgr24(255, 255, 195) },
        { 't', new Bgr24(245, 245, 255) },
        { 'u', new Bgr24(235, 235, 255) },
        { 'v', new Bgr24(225, 225, 255) },
        { 'w', new Bgr24(215, 215, 255) },
        { 'x', new Bgr24(255, 245, 245) },
        { 'y', new Bgr24(255, 235, 235) },
        { 'z', new Bgr24(255, 225, 225) },
        { (char)32, new Bgr24(255, 215, 215) }
    };

    private readonly int _pixelCount;
    private readonly Image<Bgr24> _image;

    public ImageFile(string imagePath)
    {
        _image = Image.Load<Bgr24>(imagePath);
        _pixelCount = _image.Height * _image.Width;
    }

    public void Encode(string data)
    {
        data = data.ToLower();

        if (data.Length > _pixelCount)
        {
            Console.WriteLine("Data too long!");
            return;
        }

        var dataIndex = 0;
        var done = false;

        for (var i = 0; i < _image.Width; i++)
        {
            for (var j = 0; j < _image.Height; j++)
            {
                _image[i, j] = CharColors[data[dataIndex]];

                // ReSharper disable once InvertIf
                if (++dataIndex > data.Length - 1)
                {
                    done = true;
                    break;
                }
            }

            if (done) break;
        }

        Console.WriteLine("Done! Use .Save()!");
    }

    public void Save(string path)
    {
        _image.SaveAsJpeg(path);
        Console.WriteLine($"Saved to {path}");
    }
}