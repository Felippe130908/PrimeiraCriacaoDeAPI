namespace ApiUsuarios.DTO
{
    public class UsuarioDTO

    {
        public int ID { get; set; } //Modificadores da variálvel nesse caso ID, que nos permite acessar e modificar os valores da variável
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}