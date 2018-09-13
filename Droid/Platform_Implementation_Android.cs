using System;
using System.IO;
using DFS.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Platform_Implementation_Android))]
namespace DFS.Droid
{
    public class Platform_Implementation_Android : IPlatformPath
    {
        public Platform_Implementation_Android()
        {
        }

        public String GetPlatformPath(String fileName)
        {
        string fullPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),fileName);
        return fullPath;

        }
    }
}
