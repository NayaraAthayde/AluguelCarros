using AluguelCarros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Dominio.Entidades
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public double Valor { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Marca))
                throw new DominioException("Marca não pode estar em branco");
            if (String.IsNullOrEmpty(Modelo))
                throw new DominioException("Modelo não pode estar em branco");
            if (String.IsNullOrEmpty(Cor))
                throw new DominioException("Cor não pode estar em branco");
            if (Valor < 0)
                throw new DominioException("Valor não pode ser negativo");
        }
    }
}
