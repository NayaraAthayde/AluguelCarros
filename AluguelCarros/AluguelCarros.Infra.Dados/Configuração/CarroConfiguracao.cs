using AluguelCarros.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Infra.Dados.Configuração
{
    public class CarroConfiguracao : EntityTypeConfiguration<Carro>
    {
        public CarroConfiguracao()
        {
            ToTable("TBCarro");

            HasKey(c => c.Id);

            Property(c => c.Marca).IsRequired().HasMaxLength(250);

            Property(c => c.Modelo).IsRequired().HasMaxLength(300);

            Property(c => c.Cor).IsRequired().HasMaxLength(30);
            
        }
    }
}
