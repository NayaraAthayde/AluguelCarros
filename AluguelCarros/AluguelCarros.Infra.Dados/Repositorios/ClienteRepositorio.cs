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
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AluguelCarrosContexto _contexto;
        public ClienteRepositorio(AluguelCarrosContexto contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);

            _contexto.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public Cliente BuscarPorNome(string nome)
        {
            return _contexto.Clientes
                .Where(p => p.PrimeiroNome == nome)
                .FirstOrDefault();
        }

        public List<Cliente> BuscarTodos()
        {
            return _contexto.Clientes.ToList();
        }

        public void Deletar(Cliente cliente)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(cliente);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(cliente);
            }
            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();
        }

        public void Editar(Cliente cliente)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(cliente);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(cliente);
            }
            _contexto.SaveChanges();
        }
    }
}
