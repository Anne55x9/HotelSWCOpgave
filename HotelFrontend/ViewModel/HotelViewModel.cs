using HotelFrontend.Connection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontend.ViewModel
{
    public class HotelViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Guest> guestList;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public ObservableCollection<Guest> GuestList
        {
            get { return guestList; }
            set
            {
                guestList = value;
                OnPropertyChanged(nameof(GuestList));
            }
        }

        public HotelViewModel()
        {
            Facade facade = new Facade();
            GuestList = facade.GetAllGuests().Result;
        }


    }
}
