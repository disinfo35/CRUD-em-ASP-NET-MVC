using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexaoBD
{
    class UsuarioAplicacao
    {
        private bd bd;
        

        private void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Usuario(Nome, Cargo, DataCadastro)";
            strQuery += string.Format("VALUES ('{0}','{1}','{2}')", usuario.Nome, usuario.Cargo, usuario.DataCadastro
                );
            using(bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE usuario SET ";                                           
            strQuery += string.Format("Nome = '{0}',", usuario.Nome);
            strQuery += string.Format("Cargo = '{0}',", usuario.Cargo);
            strQuery += string.Format("DataCadastro = '{0}'", usuario.DataCadastro);
            strQuery += string.Format("WHERE UsuarioId = {0}", usuario.UsuarioId);

            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if(usuario.UsuarioId > 0)
            {
                Alterar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }
            
        public void Excluir(int id)
        {
            using(bd = new bd())
            {
                var strQuery = string.Format("DELETE FROM Usuario WHERE UsuarioId = {0}", id);
                bd.ExecutaComando(strQuery );
            }
        }

        public List<Usuario> ListarTodos()
        {                          
            using (bd = new bd())
            {
                var strQuery = "SELECT * FROM Usuario";
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ReaderEmLista(retorno);
            }
        }

        private List<Usuario>ReaderEmLista(SqlDataReader reader)
        {
            var Usuario = new List<Usuario>();

            while (reader.Read())
            {
                var tempoObjeto = new Usuario()
                {
                    UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Cargo = reader["Cargo"].ToString(),
                    DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString())
                };

                Usuario.Add(tempoObjeto);
            }

            reader.Close();
            return Usuario;
        }
     }
}
