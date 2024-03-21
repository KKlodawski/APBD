namespace Zadanie9.models;

public class Users
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireTime { get; set; }
}