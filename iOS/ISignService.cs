using System;
using DFS.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ISignService))]
namespace DFS.iOS
{
	public class ISignService : ISign
	{
		public string Sign()
		{
			string savedFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/temp_" + DateTime.Now.ToString("yyyy_mm_dd_hh_mm_ss") + ".png";
			return savedFileName;
		}
	}
}
