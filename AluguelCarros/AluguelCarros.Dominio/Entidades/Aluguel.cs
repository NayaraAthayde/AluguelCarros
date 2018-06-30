using AluguelCarros.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Dominio.Entidades
{
    public class Aluguel
    {
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Carro Carro { get; set; }
        public int Dias { get; set; }

        public Aluguel(Cliente cliente, Carro carro, int dias)
        {
            Cliente = cliente;
            Carro = carro;
            Dias = dias;
        }
        private Aluguel() { }
        public double ValorTotal
        {
            get
            {
                return Carro.ValorDiario * Dias;
            }
        }
        public void Validar()
        {
            if (Cliente == null)
                throw new DominioException("precisa ter um cliente");
            if (Carro == null)
                throw new DominioException("precisa ter um carro");
            if (Dias < 0)
                throw new DominioException("precisa ser alugado por pelo menos 1 dia");
        }
    }
}
