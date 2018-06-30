using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Dominio.Excecoes
{
    public class DominioException : Exception
    {
        public DominioException(string message)
            : base(message)
        {
        }
    }
}
