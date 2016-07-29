using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Color = ColorPreview.Model.Color;

namespace ColorPreview
{
    public class ColorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var modelColoer = value as Color;

            if (modelColoer != null)
            {
                return System.Windows.Media.Color.FromRgb(modelColoer.R, modelColoer.G, modelColoer.B);
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
