using ApiUsuarios.DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ApiUsuarios.DAO
{
    public class UsuarioDAO
    {
        public List<UsuarioDTO> /*tipo do retorno*/   ListarUsuarios() /*tipo do método*/
        {
            var conexao = ConnectionFactory.Build();
            
            conexao.Open();

            var query = "select * from tb_usuarios";
            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();
            var usuarios = new List<UsuarioDTO>();

            while (dataReader.Read())
            {
                var usuario = new UsuarioDTO();
                usuario.ID = int.Parse(dataReader["ID"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.Telefone = dataReader["Telefone"].ToString();
                usuarios.Add(usuario);
            }
            conexao.Close();

            return usuarios;
        }
    }
}