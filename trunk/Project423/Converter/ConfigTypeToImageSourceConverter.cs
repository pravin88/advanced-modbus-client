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
    /// <summary>
    /// Converts a configuraiton Enumtype to its corresponding image
    /// The image is for loading in tree view
    /// </summary>
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
                    imagePath = Directory.GetCurrentDirectory() + "\\images\\folder.jpg";
                    break;
                case EnumConfigurationType.RegisterGroup:
                    imagePath = Directory.GetCurrentDirectory() + "\\images\\device.jpg";
                    break;
            }

            return Utilities.CreateImage(imagePath);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        public static BitmapImage convert(EnumConfigurationType configType)
        {
            ConfigTypeToImageSourceConverter converter = new ConfigTypeToImageSourceConverter();
            return (BitmapImage)converter.Convert(configType, typeof(BitmapImage), null, null);
        }
    }
}
