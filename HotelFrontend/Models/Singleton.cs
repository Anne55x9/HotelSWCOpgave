using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFrontend.ViewModel;
using System.Collections.ObjectModel;

namespace HotelFrontend.Models
{
    public class Singleton
    {
        public ObservableCollection<Guest> GuestList { get; set; }

        private static Singleton instance;

        private Singleton()
        {
            GuestList = new ObservableCollection<Guest>();
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


    }
}
