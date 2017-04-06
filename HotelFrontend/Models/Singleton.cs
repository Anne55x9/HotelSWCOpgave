using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFrontend.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HotelFrontend.Models 
{
    public class Singleton : INotifyPropertyChanged
    {
        public Guest SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));

            }
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public ObservableCollection<Guest> GuestList { get; set; }
        public ObservableCollection<NoOfBookingsGuest> NoOfBookings { get; set; }

        private static Singleton instance;
        private Guest selectedGuest;

        public event PropertyChangedEventHandler PropertyChanged;

        private Singleton()
        {
            GuestList = new ObservableCollection<Guest>();
            NoOfBookings = new ObservableCollection<NoOfBookingsGuest>();
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }

    }
}
