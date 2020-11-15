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
    public partial class CepDetails : ContentPage
    {
        public CepDetails(AddressRepository address)
        {
            InitializeComponent();
            NUMBERCEP.Text = address.Cep;
            CEP.Text = string.Format("Endereço: {0}, {1}, {2}, {3}, ", address.Logradouro, address.Bairro, address.Localidade, address.Uf);
        }
        
        public void redirectToCepList(object sender, EventArgs args)
        {
            App.Current.MainPage = new Tabbed();
        }


    }
}