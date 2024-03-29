﻿namespace Essa.Framework.Util.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    public class BooleanInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
}
