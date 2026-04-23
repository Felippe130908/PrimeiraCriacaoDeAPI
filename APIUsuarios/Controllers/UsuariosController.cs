using ApiUsuarios.DAO;
using ApiUsuarios.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")] //Configuração da rota
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet] //Define o tipo do método HTTP, no caso é um get
        [Route("listar")] //Define a Rota HTTP
        public IActionResult Listar()
        {
            var dao = new UsuarioDAO();
            var usuarios = dao.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();
            dao.CadastrarUsuario(usuario);

            return Ok("Usuário cadastrado com sucesso!");
        }

        // Define que esse método responde a requisições HTTP do tipo PUT (usado para atualizar dados)
        [HttpPut]

        // Define a rota da API, indicando que será algo como: /atualizar/1 (onde 1 é o id)
        [Route("atualizar/{id}")]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] UsuarioDTO usuario)
        {
            // Cria uma instância da classe responsável por acessar o banco de dados
            var dao = new UsuarioDAO();

            // Chama o método de atualização no banco, passando o id e os dados do usuário
            // Retorna a quantidade de linhas afetadas no banco
            var linhasAfetadas = dao.AtualizarUsuario(id, usuario);

            // Verifica se nenhuma linha foi alterada (ou seja, usuário não encontrado)
            if (linhasAfetadas == 0)
                // Retorna erro 404 (não encontrado) com mensagem
                return NotFound("Usuário não encontrado.");

            // Se deu certo, retorna status 200 (OK) com mensagem de sucesso
            return Ok("Usuário atualizado com sucesso!");
        }


        // Define que esse método responde a requisições HTTP do tipo DELETE (usado para excluir dados)
        [HttpDelete]

        // Define a rota da API, por exemplo: /deletar/1 (onde 1 é o id do usuário)
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            // Cria uma instância da classe que acessa o banco de dados
            var dao = new UsuarioDAO();

            // Chama o método que deleta o usuário pelo id
            // Retorna quantas linhas foram afetadas no banco
            var linhasAfetadas = dao.DeletarUsuario(id);

            // Se nenhuma linha foi afetada, significa que o usuário não existe
            if (linhasAfetadas == 0)
                // Retorna erro 404 (não encontrado)
                return NotFound("Usuário não encontrado.");

            // Se deu certo, retorna status 200 (OK) com mensagem de sucesso
            return Ok("Usuário excluído com sucesso!");
        }
    }
}
