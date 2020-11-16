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
            GetAddressBase();
            InitializeComponent();
            LIST.Refreshing += refreshPage;
        }

        private async void GetAddressBase()
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

        private async void refreshPage(object sender, EventArgs e)
        {
            GetAddressBase();
            await Task.Delay(3000);
            LIST.ItemsSource = addressRepositories;
            LIST.IsRefreshing = false;
        }
    }
}