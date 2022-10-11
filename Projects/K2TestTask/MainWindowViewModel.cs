using System;
using System.Collections.Generic;
using System.IO;
using WPFBases;

namespace K2TestTask
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private string _SQLServerInstance;

        public string SQLServerInstance
        {
            get => _SQLServerInstance;
            set
            {
                _SQLServerInstance = value;
                RaisePropertyChanged();
            }
        }

        private string _databaseName;

        public string DatabaseName
        {
            get => _databaseName;
            set
            {
                _databaseName = value;
                RaisePropertyChanged();
            }
        }

        private string _SQLUser;

        public string SQLUser
        {
            get => _SQLUser;
            set
            {
                _SQLUser = value;
                RaisePropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        private string _authorization;

        public string Authorization
        {
            get => _authorization;
            set
            {
                _authorization = value;
                RaisePropertyChanged();
            }
        }

        private string _textFilePath;

        public string TextFilePath
        {
            get => _textFilePath;
            set
            {
                _textFilePath = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            ReadFromFileCommand = new RelayCommand(ReadDataFromFile);
            WriteToFileCommand = new RelayCommand(WriteToFile);
            CancelCommand = new RelayCommand(() => System.Windows.Application.Current.Shutdown());
            PickFileCommand = new RelayCommand(PickSaveFile);
            LoadDefaultData();
            RetrieveLastUsedFilePath();
        }

        /// <summary>
        /// Retrieves the last used save file path from the lastFilePath.txt (if it exists) 
        /// and puts it into TextFilePath if it does.
        /// </summary>
        private void RetrieveLastUsedFilePath()
        {
            if (File.Exists("lastFilePath.txt"))
            {
                string lastPath = File.ReadAllText("lastFilePath.txt");
                if (lastPath != null && lastPath != "")
                    TextFilePath = lastPath;
            }
        }

        /// <summary>
        /// Displays a pick file dialog to select the file that data will be saved to.
        /// </summary>
        private void PickSaveFile()
        {
            string pickedFile = Helpers.PickFileDialog("Pick server data file", FileFilter: "Pliki txt (*.txt)|*.txt");
            if (pickedFile != "")
            {
                TextFilePath = pickedFile;
                RaisePropertyChanged(nameof(TextFilePath));
            }
        }

        /// <summary>
        /// Reads data from existing scrambled data files, de-scrambles it and puts that data into their respective fields.
        /// </summary>
        private void ReadDataFromFile()
        {
            string pickedFile = Helpers.PickFileDialog("Pick server data file", FileFilter: "Pliki txt (*.txt)|*.txt");
            if (pickedFile != "")
            {
                string allText = File.ReadAllText(pickedFile);
                string[] lines = allText.Split(new string[] { Environment.NewLine },StringSplitOptions.None);
                List<string> decodedLines = new List<string>();

                foreach (var line in lines)
                {
                    decodedLines.Add(Zink.ScrambleString.StringExtensions.Scramble(line));
                }

                SQLServerInstance = decodedLines[1];
                DatabaseName = decodedLines[2];
                SQLUser = decodedLines[3];
                Password = decodedLines[4];
                Authorization = decodedLines[5];
            }
        }

        public void LoadDefaultData()
        {
            SQLServerInstance = "Zink-2011\\MMC";
            DatabaseName = "MMC_Daten";
            SQLUser = "sa";
            Password = "78267@mmc";
            Authorization = "FALSE";
            TextFilePath = "M:\\MMC\\Daten\\Server.txt";
        }

        /// <summary>
        /// Scrambles the data from the fields, and then saves it into a txt file with the given path.
        /// </summary>
        private void WriteToFile()
        {
            FileInfo saveFile = new FileInfo(TextFilePath);

            if (!saveFile.Exists)
            {
                System.Windows.MessageBox.Show("The given save file doesn't exist.");
                return;
            }

            string connectionString = "Data Source=" + SQLServerInstance + ";Initial Catalog=" + DatabaseName + ";User ID=" + SQLUser + ";Password=" + Password;

            // Scramble the data and put it into the string
            string plainData =
                Zink.ScrambleString.StringExtensions.Scramble(connectionString) + Environment.NewLine +
                Zink.ScrambleString.StringExtensions.Scramble(SQLServerInstance) + Environment.NewLine +
                Zink.ScrambleString.StringExtensions.Scramble(DatabaseName) + Environment.NewLine +
                Zink.ScrambleString.StringExtensions.Scramble(SQLUser) + Environment.NewLine +
                Zink.ScrambleString.StringExtensions.Scramble(Password) + Environment.NewLine +
                Zink.ScrambleString.StringExtensions.Scramble(Authorization);


            File.WriteAllText(saveFile.FullName, plainData);

            System.Windows.MessageBox.Show("Saved to the file.");
            File.WriteAllText("lastFilePath.txt", TextFilePath);

            System.Windows.Application.Current.Shutdown();
        }

        public RelayCommand ReadFromFileCommand { get; }
        public RelayCommand WriteToFileCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand PickFileCommand { get; }
    }
}
