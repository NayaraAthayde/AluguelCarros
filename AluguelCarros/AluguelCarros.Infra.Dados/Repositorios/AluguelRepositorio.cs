using AluguelCarros.Dominio.Contratos;
using AluguelCarros.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelCarros.Dominio.Entidades;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace AluguelCarros.Infra.Dados.Repositorios
{
    public class AluguelRepositorio : IAluguelRepositorio
    {
        private readonly AluguelCarrosContexto _contexto;
        public AluguelRepositorio(AluguelCarrosContexto contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Aluguel aluguel)
        {
            _contexto.Aluguel.Add(aluguel);

            _contexto.SaveChanges();
        }

        public Aluguel BuscarPorId(int id)
        {
            return _contexto.Aluguel.Find(id);
        }

        public List<Aluguel> BuscarTodos()
        {
            return _contexto.Aluguel.ToList();
        }

        public void Deletar(Aluguel aluguel)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(aluguel);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Aluguel.Attach(aluguel);
            }
            _contexto.Aluguel.Remove(aluguel);
            _contexto.SaveChanges();
        }

        public void Editar(Aluguel aluguel)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(aluguel);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Aluguel.Attach(aluguel);
            }
            _contexto.SaveChanges();
        }
    }
}
