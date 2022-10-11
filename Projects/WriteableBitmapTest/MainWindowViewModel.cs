using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModelBaseNamespace;

namespace WriteableBitmapTest
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {


            // Using the relative path with a BitmapImage works, so the relative path is correct
            //Uri relativePath = new Uri(@"Images\missingProfile.jpg", UriKind.Relative);
            //Image = new BitmapImage(relativePath);

            // Using a absolute path with a WriteableBitmap also works
            //Uri absolutePath = new Uri(@"C:\Users\mooshmore\Downloads\missingProfile.jpg", UriKind.Absolute);
            //BitmapImage absoluteImage = new BitmapImage(absolutePath);
            //Image = new WriteableBitmap(absoluteImage);

            //But using a relative path with a WriteableBitmap doesn't work
            //new Uri("pack://application:,,,/images/jamsnaps-dark.png");

            Uri relativePath = new Uri(@"pack://application:,,,/images/missingProfile.jpg");
            BitmapImage relativeImage = new BitmapImage(relativePath);
            Image = new WriteableBitmap(relativeImage);

            //var path = new AssemblyName(Assembly.GetCallingAssembly().FullName).Name + ";component/" + @"Images\missingProfile.jpg";
            //var uri = new Uri(path, UriKind.Relative);
            //using (var stream = Application.GetResourceStream(uri)?.Stream)
            //{
            //    var source = new BitmapImage();
            //    source.BeginInit();
            //    source.CreateOptions = BitmapCreateOptions.None;
            //    source.StreamSource = stream;
            //    source.EndInit();
            //    Image = new WriteableBitmap(source);
            //}

            //new Uri("pack://application:,,,/images/jamsnaps-dark.png");
        }

        //public BitmapImage Image { get; set; }

        public WriteableBitmap Image { get; set; }


    }
}
