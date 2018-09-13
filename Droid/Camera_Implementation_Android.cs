using System;
using System.IO;
using DFS.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Camera_Implementation_Android))]
namespace DFS.Droid
{
    public class Camera_Implementation_Android : ICamera
    {
        public Camera_Implementation_Android()
        {
        }

        public string GetImagePath(Object CurrentObject)
        {
            string fullPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "MyData.db");
            return fullPath;
        }
    }
}
