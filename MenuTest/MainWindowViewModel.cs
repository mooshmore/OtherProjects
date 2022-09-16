using PlaylistSaver.ProgramData.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuTest
{
    public class MainWindowViewModel
    {
        public RelayCommand AfsluitenCommand { get; }
        public RelayCommand BoekBeheerCommand { get; }
        public RelayCommand AuteurBeheerCommand { get; }
        public RelayCommand UitgeverBeheerCommand { get; }

        public MainWindowViewModel()
        {
            AfsluitenCommand = new RelayCommand(Afsluiten);
            AfsluitenCommand = new RelayCommand(BoekBeheer);
            AfsluitenCommand = new RelayCommand(AuteurBeheer);
            AfsluitenCommand = new RelayCommand(UitgeverBeheer);
        }

        private void UitgeverBeheer()
        {
            throw new NotImplementedException();
        }

        private void AuteurBeheer()
        {
            throw new NotImplementedException();
        }

        private void BoekBeheer()
        {
            throw new NotImplementedException();
        }

        private void Afsluiten()
        {
            throw new NotImplementedException();
        }
    }
}
