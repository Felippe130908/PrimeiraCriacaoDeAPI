using ApiUsuarios.DAO;
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
    }
}
