using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Project423
{
    public class Utilities
    {
        public static BitmapImage CreateImage(string path)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(path);
            myBitmapImage.EndInit();
            return myBitmapImage;
        }
    }
}
