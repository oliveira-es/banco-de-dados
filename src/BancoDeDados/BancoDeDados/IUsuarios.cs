using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public interface IUsuarios
    {
        void Salvar(Usuario usuario);

        Usuario ObterPorId(int id);

        IList<Usuario> ObterTodos();

        IList<Usuario> ObterTodos(string termo);

        void Excluir(int id);
    }
}
