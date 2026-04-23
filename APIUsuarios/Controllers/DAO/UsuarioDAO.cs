using ApiUsuarios.DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ApiUsuarios.DAO
{
    public class UsuarioDAO
    {
        // Método que retorna uma lista de usuários
        public List<UsuarioDTO> /*tipo do retorno*/ ListarUsuarios() /*tipo do método*/
        {
            // Cria uma conexão com o banco de dados usando a ConnectionFactory
            var conexao = ConnectionFactory.Build();

            // Abre a conexão com o banco
            conexao.Open();

            // Query SQL para buscar todos os dados da tabela tb_usuarios
            var query = "select * from tb_usuarios";

            // Cria o comando SQL passando a query e a conexão
            var comando = new MySqlCommand(query, conexao);

            // Executa o comando e armazena o resultado em um DataReader
            var dataReader = comando.ExecuteReader();

            // Cria uma lista para armazenar os usuários retornados do banco
            var usuarios = new List<UsuarioDTO>();

            // Loop que percorre cada linha retornada da consulta
            while (dataReader.Read())
            {
                // Cria um novo objeto UsuarioDTO
                var usuario = new UsuarioDTO();

                // Converte o campo ID para inteiro e atribui ao objeto
                usuario.ID = int.Parse(dataReader["ID"].ToString());

                // Atribui os valores das colunas Nome, Email e Telefone ao objeto
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.Telefone = dataReader["Telefone"].ToString();

                // Adiciona o usuário na lista
                usuarios.Add(usuario);
            }

            // Fecha a conexão com o banco de dados
            conexao.Close();

            // Retorna a lista de usuários
            return usuarios;
        }


        // Método para cadastrar um novo usuário no banco
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            // Cria a conexão com o banco
            var conexao = ConnectionFactory.Build();

            // Abre a conexão
            conexao.Open();

            // Query SQL para inserir um novo usuário na tabela Usuarios
            var query = @"INSERT INTO Usuarios (Nome, Email, Telefone) 
          VALUES (@nome, @email, @telefone)";

            // Cria o comando SQL com a query e a conexão
            var comando = new MySqlCommand(query, conexao);

            // Adiciona os parâmetros para evitar SQL Injection
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@telefone", usuario.Telefone);

            // Executa o comando (INSERT não retorna dados)
            comando.ExecuteNonQuery();

            // Fecha a conexão com o banco
            conexao.Close();
        }


        // Retorna um inteiro (quantidade de linhas afetadas)
        public int AtualizarUsuario(int id, UsuarioDTO usuario)
        {
            // Cria a conexão com o banco de dados
            var conexao = ConnectionFactory.Build();

            // Abre a conexão
            conexao.Open();

            // Query SQL para atualizar os dados do usuário
            // Os valores serão substituídos pelos parâmetros (@nome, @email, etc.)
            var query = @"UPDATE Usuarios
                        SET Nome = @nome,
                            Email = @email,
                            Telefone = @telefone
                        WHERE Id = @id";

            // Cria o comando SQL, associando a query com a conexão
            // 'using' garante que o comando será descartado corretamente após o uso
            using var comando = new MySqlCommand(query, conexao);

            // Adiciona os parâmetros à query, evitando SQL Injection
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@telefone", usuario.Telefone);
            comando.Parameters.AddWithValue("@id", id);

            // Executa o comando no banco
            // ExecuteNonQuery é usado para UPDATE, INSERT e DELETE
            // Retorna quantas linhas foram afetadas
            var linhasAfetadas = comando.ExecuteNonQuery();

            // Fecha a conexão com o banco
            conexao.Close();

            // Retorna a quantidade de linhas alteradas
            return linhasAfetadas;
        }


        // Método responsável por deletar um usuário do banco de dados pelo id
        // Retorna um inteiro (quantidade de linhas afetadas)
        public int DeletarUsuario(int id)
        {
            // Cria a conexão com o banco de dados
            var conexao = ConnectionFactory.Build();

            // Abre a conexão
            conexao.Open();

            // Query SQL para deletar o usuário com base no id informado
            var query = @"DELETE FROM Usuarios
          WHERE Id = @id";

            // Cria o comando SQL associando a query com a conexão
            // 'using' garante que o objeto será descartado corretamente após o uso
            using var comando = new MySqlCommand(query, conexao);

            // Adiciona o parâmetro @id na query, evitando SQL Injection
            comando.Parameters.AddWithValue("@id", id);

            // Executa o comando no banco de dados
            // ExecuteNonQuery é usado para DELETE, UPDATE e INSERT
            // Retorna quantas linhas foram afetadas
            var linhasAfetadas = comando.ExecuteNonQuery();

            // Fecha a conexão com o banco
            conexao.Close();

            // Retorna a quantidade de linhas excluídas
            return linhasAfetadas;
        }
    }
}