using System;
using Xamarin.Forms;

namespace DFS.Models
{
    public class CalenerListModal
    {
        public CalenerListModal(string labelName, Color backgroundColor)
        {
            LabelName = labelName;
            ListItemColor = backgroundColor;
        }

        public string LabelName { get; set; }

        public Color ListItemColor { get; set; }
    }
}
