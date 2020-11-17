using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Desafio.Repository;
using Map = Xamarin.Forms.Maps.Map;

namespace Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchCepMap : ContentPage
    {
        public SearchCepMap()
        {
            InitializeComponent();
            Map map = new Map();
            GetAddressBase();
        }

        public async void GetAddressBase()
        {
            var addressRepositories = await App.Database.GetAddressAsync();
            GetGeoCoding(addressRepositories);   
        }

        public async void GetGeoCoding(IEnumerable<AddressRepository> list)
        {
            try
            {
                foreach (var address in list)
                {
                    var locations = await Geocoding.GetLocationsAsync(address.Logradouro);
                    var location = locations?.FirstOrDefault();
                    if(location != null)
                    {
                        map.Pins.Add(new Pin()
                        {
                            Label = address.Cep,
                            Position = new Position(location.Latitude, location.Longitude),
                            Address = address.Bairro
                        }) ;
                    }
                    Content = map;
;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        

        
    }
}