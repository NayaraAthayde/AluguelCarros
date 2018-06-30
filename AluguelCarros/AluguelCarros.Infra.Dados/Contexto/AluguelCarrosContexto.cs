using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Infra.Dados.Configuração;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Infra.Dados.Contexto
{
    public class AluguelCarrosContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Aluguel> Aluguel { get; set; }

        public AluguelCarrosContexto() : base("AluguelCarrosDB_Nayara")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new CarroConfiguracao());
            modelBuilder.Configurations.Add(new AluguelConfiguracao());
        }
    }
}
