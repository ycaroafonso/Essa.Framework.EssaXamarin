namespace Essa.Framework.Util.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    public class BooleanToStringConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "Sim" : "Não";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
