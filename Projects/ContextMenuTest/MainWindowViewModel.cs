using PlaylistSaver.ProgramData.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ContextMenuTest
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            DisplayNameCommand = new RelayCommand(DisplayName);
            DisplaySurnameCommand = new RelayCommand(DisplaySurname);

            PeopleList = new List<Person>
            {
                new Person("Julie", "Azures"),
                new Person("Mack", "McMack"),
                new Person("Josh", "Broccoli")
            };

            UpdateCurrentObjectCommand = new RelayCommand(UpdateCurrentObject);
        }

        private void UpdateCurrentObject(object person)
        {
            CurrentPerson = (Person)person;
        }

        private Person CurrentPerson { get; set; }

        public List<Person> PeopleList { get; set; }

        public void DisplayName()
        {
            MessageBox.Show("Name: " + CurrentPerson.Name);
        }

        public void DisplaySurname()
        {
            MessageBox.Show("Name: " + CurrentPerson.Surname);
        }

        public RelayCommand DisplayNameCommand { get; }
        public RelayCommand DisplaySurnameCommand { get; }
        public RelayCommand UpdateCurrentObjectCommand { get; }
    }

    public class Person
    {
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
