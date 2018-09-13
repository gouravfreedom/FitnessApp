using System;
using System.IO;
using AssetsLibrary;
using DFS.iOS;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Camera_Implementation_IOS))]
namespace DFS.iOS
{
    public class Camera_Implementation_IOS : ICamera
    {
        public Camera_Implementation_IOS()
        {
        }

        public string GetImagePath(Object CurrentObject)
        {
            //String filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "MyData.db");
            //return filename;

            var tempcontroller = new UIViewController();
             
            Camera.TakePicture (tempcontroller, (obj) =>{
            	var photo = obj.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;
            	var meta = obj.ValueForKey(new NSString("UIImagePickerControllerMediaMetadata")) as NSDictionary;
            	ALAssetsLibrary library = new ALAssetsLibrary();
            	library.WriteImageToSavedPhotosAlbum(photo.CGImage, meta, (assetUrl, error) =>
            	{
            		Console.WriteLine("assetUrl:" +assetUrl);
                });
            });;


            return "path";

        }
    }
}
