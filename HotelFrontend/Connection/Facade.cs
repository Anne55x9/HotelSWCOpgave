using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontend.Connection
{
    class Facade
    {
        private HttpClientHandler handler;
        public const string ServerUrl = "http://localhost:30351/api/";


        public async Task<ObservableCollection<Guest>> GetAllGuests()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Guests");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                ObservableCollection<Guest> guestList = await response.Content.ReadAsAsync<ObservableCollection<Guest>>();
                // var will give you a variable of type IEnumerable.
                return guestList;
            }
        }
    }
}
