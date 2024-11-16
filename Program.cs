// See https://aka.ms/new-console-template for more information
using PhotoScan;

Console.WriteLine("Hello, World!");
string[] supportedExtensions = { ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm" };
foreach (var folder in Directory.GetDirectories(@"F:\"))
{
    
    try
    {
        string[] photoFiles = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)
            .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()))
            .ToArray();
        var cnt=VideoData.ScanFiles(photoFiles);
        Console.WriteLine($"{folder} {cnt}");
    }
    catch(Exception exc)
    {
        Console.WriteLine(exc.Message);
    }
}
Console.WriteLine("Done!");