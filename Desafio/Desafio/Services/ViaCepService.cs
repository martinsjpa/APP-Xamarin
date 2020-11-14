using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Desafio.Services
{
    public class ViaCepService
    {
        private static string AddressUrl = "http://viacep.com.br/ws/{0}/json";

        public static Address FindAdressViaCep(string cep)
        {
            string address = string.Format(AddressUrl, cep);

            WebClient wc = new WebClient();

            Address result = JsonConvert.DeserializeObject<Address>(wc.DownloadString(address));

            return result;

        }
    }
}
