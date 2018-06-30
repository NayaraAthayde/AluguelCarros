using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Dominio.Contratos
{
    public interface IRepositorio<T>
    {
        void Adicionar(T entidade);

        void Editar(T entidade);

        T BuscarPorId(int id);

        List<T> BuscarTodos();

        void Deletar(T entidade);
    }
}
