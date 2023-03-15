// See https://aka.ms/new-console-template for more information

namespace SteganographyPlayground;

internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Steganography playground!");
        var imagePath = Utils.GetImagePath();
        var image = new ImageFile(imagePath);
    }
}
