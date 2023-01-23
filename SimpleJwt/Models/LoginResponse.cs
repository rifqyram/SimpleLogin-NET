namespace SimpleJwt.Models;

public class LoginResponse
{
    public string Email { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}