using Desafio.Models;
using Desafio.Repository;
using Desafio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Desafio.Views
{
    public partial class MainPage : ContentPage
    {
        public List<AddressRepository> addressRepositories { get; set; }

        public MainPage()
        {
            InitializeComponent();
          
        }

        public void eventClick(object sender, EventArgs args)
        {
            FindCep();
        }

        public async Task<int> FindCep()
        {
            var find = CEP.Text.Trim();
            find = find.Replace("-", "");

            if (isValidCep(find))
            {
                try
                {
                    addressRepositories = await GetAddressBase();
                    Address result = ViaCepService.FindAdressViaCep(find);

                    if (!addressRepositories.Contains((object)result))
                    {
                        var task = await SaveAddressBase(new AddressRepository(result.Cep, result.Logradouro, result.Bairro, result.Logradouro, result.Uf));
                        
                    }


                    RESULT.Text = string.Format("Endereço: {0}, {1}, {2}, {3}, {4}", result.Cep, result.Logradouro, result.Bairro, result.Localidade, result.Uf);
                    return 1;
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro:", e.Message, "OK");
                }

            }

            return 0;
            
        }

        private bool isValidCep(string cep)
        {
            if(cep.Length != 8)
            {
                DisplayAlert("Erro: CEP Inválido", "O CEP deve precisa ter 8 caractéres", "OK");
                return false;
            }
            int checkCep = 0;
            if(!int.TryParse(cep,out checkCep))
            {
                DisplayAlert("Erro: CEP Inválido", "O CEP deve ser composto somente por numeros", "OK");
                return false;
            }

            return true;
        }

        private async Task<List<AddressRepository>> GetAddressBase()
        {
            return  await App.Database.GetAddressAsync();
        }

        private async Task<int> SaveAddressBase(AddressRepository address)
        {
            return  await App.Database.SaveAddressAsync(address);
        }
    }
}
