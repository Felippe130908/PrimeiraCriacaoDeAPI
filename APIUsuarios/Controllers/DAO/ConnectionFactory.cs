using MySql.Data.MySqlClient;

public class ConnectionFactory
{
    public static MySqlConnection Build()
    {
        var connectionString = "Server=localhost;Database=bd_Apostilas;Uid=root;Pwd=root;";
        return new MySqlConnection(connectionString);
    }
}
/* Server - Endereço da web onde nosso banco de dados está alocado; 
   Database -> Nome do banco de dados
   Uid -> Username
   Pwd -> Password (senha)
*/