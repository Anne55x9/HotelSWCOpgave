using HotelFrontend.Common;
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
        private Guest selectedGuest;

        public event PropertyChangedEventHandler PropertyChanged;

        public Guest SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));
            }
        }
        public string Name
        {
            get
            {
                if (selectedGuest != null)
                {
                    return selectedGuest.Name;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                selectedGuest.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Address
        {
            get
            {
                if (selectedGuest != null)
                {
                    return selectedGuest.Address;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                selectedGuest.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public RelayCommand DeleteGuestCommand { get; set; }
        public RelayCommand UpdateGuestCommand { get; set; }
        public RelayCommand CreateGuestCommand { get; set; }

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

            DeleteGuestCommand = new RelayCommand(DeleteGuest);
            UpdateGuestCommand = new RelayCommand(UpdateGuest);
            CreateGuestCommand = new RelayCommand(CreateGuest);
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

        public void DeleteGuest()
        {
            Facade facade = new Facade();
            facade.DeleteGuest(SelectedGuest);
        }

        public void UpdateGuest()
        {
            Facade facade = new Facade();
            facade.UpdateGuest(SelectedGuest);
        }

        public void CreateGuest()
        {
            Facade facade = new Facade();
            facade.CreateGuest(new Guest(Name, Address));
        }


    }
}
