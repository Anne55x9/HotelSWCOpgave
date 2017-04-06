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
    class NoOfBookingsGuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NoOfBookingsGuest> NoOfBookings
        {
            get { return Singleton.Instance.NoOfBookings; }
            set
            {
                Singleton.Instance.NoOfBookings = value;

                OnPropertyChanged(nameof(NoOfBookings));
            }
        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public async void LoadNoOfBookings()
        {
            try
            {
                Facade facade = new Facade();
                NoOfBookings = await facade.GetNoOfBookings();
            }
            catch (System.Net.Http.HttpRequestException)
            {
                var msg = new MessageDialog("Kan ikke forbinde til webservice");
                msg.Commands.Add(new UICommand("Prøv igen"));
                await msg.ShowAsync();
                LoadNoOfBookings();
            }
        }

        public NoOfBookingsGuestViewModel()
        {
            LoadNoOfBookings();
        }
    }
}
