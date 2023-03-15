using SixLabors.ImageSharp;

namespace SteganographyPlayground;

internal sealed class ImageFile
{
    private Image<Bgr24> _image;
    private int _pixelCount;
    
    public ImageFile(string imagePath)
    {
        _image = Image.Load<Bgr24>(imagePath);
        _pixelCount = _image.Height * _image.Width;
    }

    public void Encode(string data)
    {
        if (data.Length > _pixelCount)
        {
            Console.WriteLine("");
        }
    }
}