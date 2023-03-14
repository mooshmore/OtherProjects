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
            var cellInfos = (IEnumerable<DataGridCellInfo>)value;
            List<object> cellValues = cellInfos
                .Select(cellInfo =>
                {
                    if (!(cellInfo.Item is DataRowView dataRowView))
                    {
                        return null;
                    }

                    return dataRowView[cellInfo.Column.DisplayIndex];
                })
                .ToList();

            // Added to display that the converter value doesn't change
            cellValues.Add(new Random().Next());
            return cellValues;
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
