using MySql.Data.MySqlClient;
using System;

namespace Hamsell.Data;

public class DbContext
{
    public string Server { get; set; }
    public string DatabaseName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public MySqlConnection Connection { get; private set; }

    // Constructor accepting configuration parameters
    public DbContext(string server, string databaseName, string userName, string password)
    {
        Server = server;
        DatabaseName = databaseName;
        UserName = userName;
        Password = password;
        InitializeConnection();
    }

    private void InitializeConnection()
    {
        string connstring = $"Server={Server}; database={DatabaseName}; UID={UserName}; password={Password}";
        Connection = new MySqlConnection(connstring);
        Connection.Open();
    }

    public void Close()
    {
        Connection.Close();
    }
}