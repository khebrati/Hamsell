using MySql.Data.MySqlClient;

namespace Hamsell.Data;

public class DbContext
{
    private DbContext()
    {
        DefaultConfig();
    }

    public string Server { get; set; }
    public string DatabaseName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public MySqlConnection Connection { get; set; }

    private static DbContext _instance = null;

    public static DbContext Instance()
    {
        if (_instance == null)
            _instance = new DbContext();
        return _instance;
    }

    public void DefaultConfig()
    {
        Server = "localhost";
        DatabaseName = "Hamsell";
        UserName = "root";
        Password = "27erf@n-123k9o";
    }

    public bool IsConnect()
    {
        if (Connection == null)
        {
            if (String.IsNullOrEmpty(DatabaseName))
                return false;
            string connstring = $"Server={Server}; database={DatabaseName}; UID={UserName}; password={Password}";
            Connection = new MySqlConnection(connstring);
            Connection.Open();
        }

        return true;
    }

    public void Close()
    {
        Connection.Close();
        _instance = null;
    }
}