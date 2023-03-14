using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Utilities.WPF.BindingConverters
{
    /// <summary>
    /// A WPF functionality that allows to convert a Current Cell to a cells bound value.
    /// </summary>
    public class CellsToValuesConverter : IValueConverter
    {
        /// <summary>
        /// Converts the current cells value to the cells bound value.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cellCollection = (IEnumerable<DataGridCellInfo>)value;

            var convertedValues = new List<object>();
            foreach (var item in cellCollection)
            {
                if (item == null)
                    convertedValues.Add(null);

                DataGridCellInfo cellInfo = (DataGridCellInfo)item;

                if (cellInfo.Column == null)
                    convertedValues.Add(null);

                DataRow dataRow = ((DataRowView)cellInfo.Item).Row;
                convertedValues.Add(dataRow.ItemArray[cellInfo.Column.DisplayIndex]);
            }

            return convertedValues;
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
