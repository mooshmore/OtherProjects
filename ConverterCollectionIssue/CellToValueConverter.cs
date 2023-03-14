using System;
using System.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Utilities.WPF.BindingConverters
{
    /// <summary>
    /// A WPF functionality that allows to convert a Current Cell to a cells bound value.
    /// </summary>
    public class CellToValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts the current cells value to the cells bound value.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            DataGridCellInfo cellInfo = (DataGridCellInfo)value;

            if (cellInfo.Column == null)
                return null;

            DataRow dataRow = ((DataRowView)cellInfo.Item).Row;
            return dataRow.ItemArray[cellInfo.Column.DisplayIndex];
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
