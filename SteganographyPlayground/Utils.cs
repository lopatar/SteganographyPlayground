namespace SteganographyPlayground;

internal static class Utils
{
    public static string GetImagePath()
    {
        var imagePath = "";

        do
        {
            Console.Write("Insert image path: [*.jpeg, *.jpg ]: ");
            imagePath = Console.ReadLine();
            
        } while (imagePath == null || !(imagePath.EndsWith(".jpg") || imagePath.EndsWith(".jpeg")) || !File.Exists(imagePath));

        return imagePath;
    }
}