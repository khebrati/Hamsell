using Hamsell.Data;
using Hamsell.Models;
using MySql.Data.MySqlClient;

namespace Hamsell.Data.Repositories.User;

public class UserRepository
{
    private readonly DbContext _context;

    public UserRepository(DbContext context)
    {
        _context = context;
    }

    public void AddAccount(Account account)
    {
        string query =
            $"INSERT INTO Account (FirstName, LastName, EmailAddress, PhoneNumber,CreationDate) VALUES (\"{account.FirstName}\",\"{account.LastName}\",\"{account.EmailAddress}\",\"{account.PhoneNumber}\",\"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\")";
        var cmd = new MySqlCommand(query, _context.Connection);
        cmd.ExecuteNonQuery();
    }

    public int GetLastInsertedAccountId()
    {
        string query = "SELECT LAST_INSERT_ID()";
        var cmd = new MySqlCommand(query, _context.Connection);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    public void AddUser(Models.User user)
    {
        string query;
        if (user.CityId.HasValue)
        {
            query =
                $"INSERT INTO User (AccountId, CityId, UserStatusId) VALUES ({user.AccountId}, {user.CityId}, {user.UserStatusId})";
        }
        else
        {
            query = $"INSERT INTO User (AccountId, UserStatusId) VALUES ({user.AccountId}, {user.UserStatusId})";
        }

        var cmd = new MySqlCommand(query, _context.Connection);
        cmd.ExecuteNonQuery();
    }
}