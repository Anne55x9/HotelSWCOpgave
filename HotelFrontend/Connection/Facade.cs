using HotelFrontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontend.Connection
{
   public class Facade
    {
        private HttpClientHandler handler;
        public const string ServerUrl = "http://localhost:30351/api/";


        public async Task<ObservableCollection<Guest>> GetAllGuests()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();

                var task = client.GetAsync("Guests");
                
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                ObservableCollection<Guest> guestList = await response.Content.ReadAsAsync<ObservableCollection<Guest>>();
                
                return guestList;
            }
        }

        public async void DeleteGuest(Guest guest)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                string deleteUrl = "guests/" + guest.Guest_No;

                var task = client.DeleteAsync(deleteUrl);
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
            }

            Singleton.Instance.GuestList = await GetAllGuests();
        }

        public async void UpdateGuest(Guest guest)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();

                var task = client.PutAsJsonAsync("Guests/" + guest.Guest_No, guest);
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
            }
            Singleton.Instance.GuestList = await GetAllGuests();
        }

        public async void CreateGuest(Guest guest)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();

                var task = client.PostAsJsonAsync("Guests", guest);
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
            }
            Singleton.Instance.GuestList = await GetAllGuests();
        }



        public async Task<ObservableCollection<NoOfBookingsGuest>> GetNoOfBookings()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();

                var task = client.GetAsync("NoOfBookingsGuests");

                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                ObservableCollection<NoOfBookingsGuest> noOfBookings = await response.Content.ReadAsAsync<ObservableCollection<NoOfBookingsGuest>>();

                return noOfBookings;
            }
        }
    }
}
