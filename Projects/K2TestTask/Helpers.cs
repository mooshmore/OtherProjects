using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K2TestTask
{
    public static class Helpers
    {
        /// <summary>
        /// Opens a dialog menu that allows to pick a file ( all parameters are not required, just pass "" if you don't need them to be specified )
        /// </summary>
        /// <param name="WindowTitle">Title of the window, Ex: "Otwórz plik".</param>
        /// <param name="InitialDirectory">Initial directory, sets @"C:\Users\%UserProfile%\Desktop" by default if this parameter is empty.</param>
        /// <param name="FileFilter">Files that will be filtered, Ex: "Pliki txt (*.txt)|*.txt"</param>
        /// <returns>The path to the file, returns empty string if file doesn't exist.</returns>
        public static string PickFileDialog(string WindowTitle = "", string InitialDirectory = "", string FileFilter = "")
        {
            string pathToFile = "";
            OpenFileDialog theDialog = new OpenFileDialog
            {
                Title = WindowTitle,
                Filter = FileFilter
            };

            if (InitialDirectory == "")
                theDialog.InitialDirectory = @"C:\Users\%UserProfile%\Desktop";

            if (theDialog.ShowDialog() == DialogResult.OK)
                pathToFile = theDialog.FileName;

            return pathToFile;
        }

        /// <summary>
        /// Reverses the string.
        /// </summary>
        public static string Reverse(this string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
