namespace Hamsell.Models;

public class User
{
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int CityId { get; set; }
    public int UserStatusId { get; set; }
}