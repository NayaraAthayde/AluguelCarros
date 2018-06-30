using AluguelCarros.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Infra.Dados.Configuração
{
    public class AluguelConfiguracao : EntityTypeConfiguration<Aluguel>
    {
        public AluguelConfiguracao()
        {
            ToTable("TBAluguel");

            HasKey(c => c.Id);

            Property(c => c.Dias).IsRequired();
        }
    }
}
