using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Muggle.TeklaPlugins.KJ1002.ValueConverters {
    class UpDirectionToSelectedIndexEnumValueConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is int index)) return DependencyProperty.UnsetValue;

            return 7 - (index < 0 ? 0 : index);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is int upDirectionEnum)) return DependencyProperty.UnsetValue;

            return 7 - upDirectionEnum;
        }
    }
}
