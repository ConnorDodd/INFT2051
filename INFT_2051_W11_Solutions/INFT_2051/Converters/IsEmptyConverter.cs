using System.Globalization;

namespace INFT_2051.Converters
{
    internal class IsEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Collections.ICollection collection = value as System.Collections.ICollection;
            return collection == null || collection.Count == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
