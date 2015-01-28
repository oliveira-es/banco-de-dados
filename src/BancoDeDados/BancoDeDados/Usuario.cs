using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        internal Usuario()
        { 
            
        }

        public Usuario(string email, string nome, string senha)
        {
            this.Email = email;
            this.Nome = nome;
            this.Senha = senha;
        }
    }
}
