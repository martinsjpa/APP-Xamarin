using Desafio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CepList : ContentPage
    {
        public List<AddressRepository> addressRepositories { get; set; }
        public CepList()
        {
            GetAddressBaseAsync();
            InitializeComponent();
        }

        public async void GetAddressBaseAsync()
        {
            addressRepositories = await App.Database.GetAddressAsync();
            addressRepositories = addressRepositories.OrderByDescending(x => x.Cep).ToList();
            BindingContext = this;
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs selected)
        {
            AddressRepository address = selected.SelectedItem as AddressRepository;
            App.Current.MainPage = new CepDetails(address);
        }
    }
}