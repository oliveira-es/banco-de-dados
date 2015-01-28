using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Infra
{
    public class Usuarios : IUsuarios
    {
        protected MySqlConnection Connection { get; set; }

        public Usuarios(MySqlConnection connection)
        {
            this.Connection = connection;
        }

        public void Salvar(Usuario usuario)
        {
            var cmd = new MySqlCommand("", this.Connection);

            cmd.Parameters.AddWithValue("Email", usuario.Email);
            cmd.Parameters.AddWithValue("Nome", usuario.Nome);
            cmd.Parameters.AddWithValue("Senha", usuario.Senha);
                
            if(usuario.Id > 0)
            {
                cmd.CommandText = @"UPDATE  Usuarios
                                    SET     Nome = @Nome,
                                            Email = @Email,
                                            Senha = @Senha
                                    WHERE   Id = @Id";

                cmd.Parameters.AddWithValue("Id", usuario.Id);

                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = @"INSERT INTO Usuarios( Nome, Email, Senha)
                                                  Values(@Nome,@Email,@Senha);
                                    SELECT @@IDENTITY;";

                usuario.Id = (int)cmd.ExecuteScalar();

            }
        }


        public Usuario ObterPorId(int id)
        {
            var cmd = new MySqlCommand("SELECT * FROM Usuarios WHERE Id = @Id", this.Connection);

            cmd.Parameters.AddWithValue("Id", id);

            Usuario usuario = null;

            using (var dr = cmd.ExecuteReader())
            { 
                if(dr.Read())
                {
                    var nome = (string)dr["Nome"];
                    var email = dr.GetString("Email");
                    var senha = dr["Senha"].ToString();

                    usuario = new Usuario();

                    usuario.Id = id;
                    usuario.Nome = nome;
                    usuario.Email = email;
                    usuario.Senha = senha;

                    usuario.Id = id;
                }
            }

            return usuario;
        }

        public IList<Usuario> ObterTodos()
        {
            var cmd = new MySqlCommand("SELECT * FROM Usuarios", this.Connection);

            List<Usuario> usuarios = new List<Usuario>();

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var id = (int)dr["Id"];
                    var nome = (string)dr["Nome"];
                    var email = dr.GetString("Email");
                    var senha = dr["Senha"].ToString();

                    var usuario = new Usuario();

                    usuario.Id = id;
                    usuario.Nome = nome;
                    usuario.Email = email;
                    usuario.Senha = senha;

                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public IList<Usuario> ObterTodos(string termo)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
