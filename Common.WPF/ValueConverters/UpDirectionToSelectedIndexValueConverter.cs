using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Muggle.TeklaPlugins.Common.WPF.ValueConverters {
    public class UpDirectionToSelectedIndexValueConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is not int index) return DependencyProperty.UnsetValue;

            return 7 - (index < 0 ? 0 : index);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is not int upDirectionEnum) return DependencyProperty.UnsetValue;

            return 7 - upDirectionEnum;
        }
    }
}
