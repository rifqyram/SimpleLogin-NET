using SimpleJwt.Entities;

namespace SimpleJwt.Security;

public interface IJwtUtils
{
    string GenerateToken(UserCredential userCredential);
}