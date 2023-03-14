using Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ViewModelBaseNamespace;

namespace ConverterCollectionIssue
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            DataTable= new DataTable();
            DataTable.Columns.Add("Column0");
            DataTable.Columns.Add("Column1");

            DataTable.Rows.Add("0A", "1A");
            DataTable.Rows.Add("0B", "1B");
            DataTable.Rows.Add("0C", "1C");
            DataTable.Rows.Add("0D", "1D");
            DataTable.Rows.Add("0E", "1E");

            ConvertCommand = new RelayCommand(ConverterMethod);
            DirectCommand = new RelayCommand(DirectMethod);
            SingleCommand = new RelayCommand(SingleMethod);
        }

        // Multi cell with converting
        private void ConverterMethod(object obj)
        {
            // With converting
            var collection = (List<object>)obj;
            foreach (var item in collection)
            {
                Debug.WriteLine(item.ToString());
            }

            Console.WriteLine("Done displaying");
        }

        // Multi cell without converting
        private void DirectMethod(object obj)
        {
            var cellCollection = (IEnumerable<DataGridCellInfo>)obj;
            List<object?> cellValues = cellCollection
                .Select(cellInfo =>
                {
                    if (!(cellInfo.Item is DataRowView dataRowView))
                    {
                        return null;
                    }

                    return dataRowView[cellInfo.Column.DisplayIndex];
                })
                .ToList();


            foreach (var item in cellValues)
            {
                Debug.WriteLine(item?.ToString());
            }

            Console.WriteLine("Done displaying");
        }

        // Current cell with converting
        private void SingleMethod(object obj)
        {
            Debug.WriteLine(obj.ToString());
            Console.WriteLine("Done displaying");
        }

        public DataTable DataTable { get; set; }
        public RelayCommand ConvertCommand { get; set; }
        public RelayCommand DirectCommand { get; set; }
        public RelayCommand SingleCommand { get; set; }
    }
}
