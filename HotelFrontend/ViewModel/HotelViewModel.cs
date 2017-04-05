using HotelFrontend.Connection;
using HotelFrontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HotelFrontend.ViewModel
{
    public class HotelViewModel : INotifyPropertyChanged
    {
        

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
            get { return Singleton.Instance.GuestList; }
            set
            {
                Singleton.Instance.GuestList = value;
                OnPropertyChanged(nameof(GuestList));
            }
        }

        public HotelViewModel()
        {
           LoadFromDB();
        }

        public async void LoadFromDB()
        {
            try
            {
                Facade facade = new Facade();
                GuestList = await facade.GetAllGuests();
            }
            catch (System.Net.Http.HttpRequestException)
            {
                var msg = new MessageDialog("Kan ikke forbinde til webservice");
                msg.Commands.Add(new UICommand("Prøv igen"));
                await msg.ShowAsync();
                LoadFromDB();
            }
            
        }

    }
}
