using Shell32;
using System.IO;
using MetadataExtractor;

namespace PhotoScan
{
    internal class VideoData
    {
        public static Dictionary<string, string> photos = new Dictionary<string, string>();
        public static int ScanFiles(string[] photoFiles)
        {
            int cnt = 0;
            string outFolder = "W:\\Video";
            foreach (string photoFile in photoFiles)
            {
                var x= MetadataExtractor.ImageMetadataReader.ReadMetadata(photoFile);
                string outfolder = "";
                var fileInfo = new FileInfo(photoFile);

                //outfolder = Path.Combine(outFolder, $"{fileInfo.Extension}\\{createTime.Year}\\{createTime.Month}\\{createTime.Day}");

                var folder = new DirectoryInfo(outfolder);
                if (!folder.Exists)
                {
                    folder.Create();
                }
                var outfile = Path.Combine(outfolder, fileInfo.Name);
                if (!File.Exists(outfile))
                {
                    File.Copy(photoFile, outfile);
                    cnt++;
                }

            }
            return cnt;
        }

    }
}
