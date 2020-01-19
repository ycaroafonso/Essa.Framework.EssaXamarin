namespace Essa.Framework.XamarinUtil.Converter
{
    using System;
    using System.Globalization;


    public interface IValueConverter
    {

    }

    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
