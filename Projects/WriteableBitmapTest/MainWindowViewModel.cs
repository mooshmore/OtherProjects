using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // But using a relative path with a WriteableBitmap doesn't work
            //Uri relativePath = new Uri(@"Images\missingProfile.jpg", UriKind.Relative);
            //BitmapImage relativeImage = new BitmapImage(relativePath);
            //Image = new WriteableBitmap(relativeImage);
        }

        //public BitmapImage Image { get; set; }

        public WriteableBitmap Image { get; set; }


    }
}
