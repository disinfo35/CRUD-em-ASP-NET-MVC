using System;
using System.Data.SqlClient;

namespace ConexaoBD
{
    class Program
    {
        static void Main(string[] args)
        {
            var bd = new bd();
            var app = new UsuarioAplicacao();

            SqlConnection conexao = new SqlConnection(@"data source=DESKTOP-IGOO191\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=SistemaBD");
            conexao.Open();

            Console.Write("Digite o nome do usuário: ");
            string Nome = Console.ReadLine();

            Console.Write("Digite o cargo do usuário: ");
            string Cargo = Console.ReadLine();

            Console.Write("Digite a data de cadastro: ");
            string Data = Console.ReadLine();

            var usuario = new Usuario
            {
                Nome = Nome,
                Cargo = Cargo,
                DataCadastro = DateTime.Parse(Data)
            };

            //usuario.UsuarioId = 16;

            //app.Excluir(8);

            app.Salvar(usuario);

            var dados = app.ListarTodos();

            foreach (var Usuario in dados)
            {
                Console.WriteLine("UsuarioId:{0}, Nome:{1}, Cargo:{2}, DataCadastro:{3}", Usuario.UsuarioId, Usuario.Nome, Usuario.Cargo, Usuario.DataCadastro);
            }   
        }
    }
}
