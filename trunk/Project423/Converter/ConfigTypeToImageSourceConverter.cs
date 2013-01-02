using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.IO;

namespace Project423
{
    class ConfigTypeToImageSourceConverter : IValueConverter
    {
        #region /*********************** Base class override **********************/

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EnumConfigurationType configType = (EnumConfigurationType)value;
            string imagePath = "";

            switch (configType)
            {
                case EnumConfigurationType.MyComputer:
                    imagePath = Directory.GetCurrentDirectory() + "\\images\\computer.jpg";
                    break;
                case EnumConfigurationType.Folder:
                    imagePath = Directory.GetCurrentDirectory() + "\\images\\folder.png";
                    break;
                case EnumConfigurationType.RegisterGroup:
                    imagePath = Directory.GetCurrentDirectory() + "\\images\\device.png";
                    break;
            }

            return CreateImage(imagePath);
        }

        public object Convertback(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region /******************* image ******************/
        private BitmapImage CreateImage(string path)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(path);
            myBitmapImage.EndInit();
            return myBitmapImage;
        }

        #endregion
    }
}
