using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;

namespace Encuesta
{
    class ColorEquipo: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var equipo = (string)value;
            var color = Color.Aquamarine;
            switch (equipo)
            {
                case "Real Madrid":
                case "Liverpool":
                    color = Color.Blue;
                    break;
                case "Barcelona":
                case "Juventus":
                    color = Color.Blue;
                    break;
                case "Machester City":
                case "Bayern Munich":
                case "Inter Milan":
                case "Atletico de Madrid":
                    color = Color.Blue;
                    break;
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
