using BancoDeDados.Infra;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario("denisferrari@azys.com.br", "Denis Ferrari", "123456");

            // MySql
            var connectionString = "AQUI TEM UMA STRING DE COÑ...";

            // Conexão
            using (var con = new MySqlConnection(connectionString))
            {

                try
                {
                    // Abrir a conexão
                    con.Open();

                    // Executar o comando
                    IUsuarios usuarios = new Usuarios(con);

                    usuarios.Salvar(usuario);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    // Fechar a conexão
                    if (con.State == System.Data.ConnectionState.Open)
                        con.Close();
                }

            }
        }
    }
}
