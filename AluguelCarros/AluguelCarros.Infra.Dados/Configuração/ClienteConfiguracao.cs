using AluguelCarros.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Infra.Dados.Configuração
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("TBCliente");

            HasKey(c => c.Id);

            Property(c => c.PrimeiroNome).IsRequired().HasMaxLength(150);

            Property(c => c.Sobrenome).IsRequired().HasMaxLength(300);

            Property(c => c.Telefone).IsRequired().HasMaxLength(30);

            Ignore(c => c.NomeCompleto);


        }
    }
}
