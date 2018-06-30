using AluguelCarros.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Testes.Base
{
    public class InializadorBanco<T> : DropCreateDatabaseAlways<AluguelCarrosContexto>
    {
        protected override void Seed(AluguelCarrosContexto context)
        {
            var cliente = ConstrutorObjeto.CriarCliente();
            var carro = ConstrutorObjeto.CriarCarro();
            var aluguel = ConstrutorObjeto.CriarAluguel();

            base.Seed(context);

            context.Aluguel.Add(aluguel);

            context.SaveChanges();
        }
    }
}
