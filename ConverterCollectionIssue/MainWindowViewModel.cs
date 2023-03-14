using Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            MutliCommand = new RelayCommand(MultiMethod);
            SingleCommand = new RelayCommand(SingleMethod);
        }

        private void MultiMethod(object obj)
        {
            var collection = (ICollection)obj;
            foreach (var item in collection)
            {
                Debug.WriteLine(item.ToString());
            }

            Console.WriteLine("Done displaying");
        }

        private void SingleMethod(object obj)
        {
            Debug.WriteLine(obj.ToString());
            Console.WriteLine("Done displaying");
        }

        public DataTable DataTable { get; set; }

        public RelayCommand MutliCommand { get; set; }
        public RelayCommand SingleCommand { get; set; }
    }
}
