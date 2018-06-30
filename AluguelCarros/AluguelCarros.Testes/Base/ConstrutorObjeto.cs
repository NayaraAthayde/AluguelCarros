using AluguelCarros.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Testes.Base
{
    public static class ConstrutorObjeto
    {
        public static Cliente CriarCliente()
        {
            return new Cliente
            {
                Id = 1,
                PrimeiroNome = "Nayara",
                Sobrenome = "Athayde",
                Telefone = "49 9 9145-6227",
                Endereco = new Endereco
                {
                    Numero = "123",
                    Logradouro = "Rua Bezerra de Menezes",
                    Bairro = "Conta Dinheiro",
                    Localidade = "Lages",
                    Uf = "SC",
                    Cep = "88519525",
                    Complemento = ""
                },
            };
        }
        public static Carro CriarCarro()
        {
            return new Carro
            {
                Id = 1,
                Marca = "Honda",
                Modelo = "Civic 2018",
                Cor = "Preto",
                ValorDiario = 1500
            };
        }
        public static Aluguel CriarAluguel()
        {
            var carro = CriarCarro();
            var cliente = CriarCliente();
            var dias = 2;
            var aluguel = new Aluguel(cliente, carro, dias);
            aluguel.Id = 1;
            return aluguel;
        }
    }
}
