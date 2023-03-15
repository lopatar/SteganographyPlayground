namespace SteganographyPlayground;

internal static class Utils
{
    public static string GetImagePath(bool saveOrOriginal = false)
    {
        var imagePath = "";
        var dynamicString = saveOrOriginal ? "save" : "original";

        do
        {
            Console.Write($"Insert {dynamicString} image path: [*.jpeg, *.jpg ]: ");
            imagePath = Console.ReadLine();
        } while (imagePath == null || !(imagePath.EndsWith(".jpg") || imagePath.EndsWith(".jpeg")) ||
                 (!File.Exists(imagePath) && !saveOrOriginal));

        return imagePath;
    }
}