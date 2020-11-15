using Desafio.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repository
{
    public class AddressRepository
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

        public AddressRepository(string cep, string logradouro, string bairro, string localidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
        }

        public AddressRepository()
        {}

        public override bool Equals(object obj)
        {
            if(obj != null)
            {
                if(typeof(Address).IsInstanceOfType(obj))
                {
                    Address convert = (Address)obj;
                    if (Cep.Equals(convert.Cep))
                        return true;
                }
            }
            
            return false;

        }
    }
}
