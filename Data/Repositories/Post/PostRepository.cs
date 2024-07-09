using Hamsell.ViewModels;
using MySql.Data.MySqlClient;

namespace Hamsell.Data.Repositories.Post;

public class PostRepository
{
    private readonly DbContext _context;

    public PostRepository(DbContext context)
    {
        _context = context;
    }

    public void AddPost(PostViewModel model)
    {
        string query =
            $"INSERT INTO Post (Title, Address, Price, PostDescription, CreationDate, PostCategoryId, CityID,PostStatusId) VALUES ('{model.Title}', '{model.Address}', {model.Price}, '{model.PostDescription}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{model.PostCategoryId}', '{model.CityId}', '1')";
        var cmd = new MySqlCommand(query, _context.Connection);
        cmd.ExecuteNonQuery();
    }
}