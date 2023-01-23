using SimpleJwt.Entities;

namespace SimpleJwt.Security;

public class SecurityUtils
{
    public string HashPassword(string password)
    {
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return hashPassword!;
    }

    public bool Validate(string text, string hash)
    {
        var verify = BCrypt.Net.BCrypt.Verify(text, hash);
        return verify;
    }
}