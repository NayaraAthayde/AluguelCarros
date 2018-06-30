using AluguelCarros.Dominio.Contratos;
using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Infra.Dados.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly AluguelCarrosContexto _contexto;
        public CarroRepositorio(AluguelCarrosContexto contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Carro carro)
        {
            _contexto.Carros.Add(carro);

            _contexto.SaveChanges();
        }

        public Carro BuscarPorId(int id)
        {
            return _contexto.Carros.Find(id);
        }

        public List<Carro> BuscarTodos()
        {
            return _contexto.Carros.ToList();
        }

        public void Deletar(Carro carro)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(carro);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Carros.Attach(carro);
            }
            _contexto.Carros.Remove(carro);
            _contexto.SaveChanges();
        }

        public void Editar(Carro carro)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(carro);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Carros.Attach(carro);
            }
            _contexto.SaveChanges();
        }
    }
}
