using Desafio.Models;
using Desafio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Desafio
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BUTTON.Clicked += FindCep;

        }

        private void FindCep(object sender, EventArgs args)
        {
            var find = CEP.Text.Trim();
            find = find.Replace("-", "");
            if(isValidCep(find))
            {
                try
                {
                    Address result = ViaCepService.FindAdressViaCep(find);

                    RESULT.Text = string.Format("Endereço: {0}, {1}, {2}, {3}, {4}", result.Cep, result.Logradouro, result.Bairro, result.Localidade, result.Uf);
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro:", e.Message, "OK");
                }
                
            }
            
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
    }
}
