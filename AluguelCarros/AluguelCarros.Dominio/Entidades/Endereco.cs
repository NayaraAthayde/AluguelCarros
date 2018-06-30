using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Dominio.Entidades
{
    public class Endereco
    {
        public string Numero { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
    }
}
