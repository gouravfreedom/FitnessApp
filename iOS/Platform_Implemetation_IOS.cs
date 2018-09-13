using System;
using System.IO;
using DFS.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Platform_Implemetation_IOS))]
namespace DFS.iOS
{
    
    public class Platform_Implemetation_IOS : IPlatformPath
    {
        public Platform_Implemetation_IOS()
        {
        }

        public String GetPlatformPath(String fileName)
        {
            String filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", fileName);
            return filename;

        }
    }
}
