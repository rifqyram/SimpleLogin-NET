using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJwt.Entities;

[Table(name: "m_user_credential")]
public class UserCredential
{
    [Key, Column(name: "id")] public Guid Id { get; set; }
    [Column(name: "email")] public string Email { get; set; } = string.Empty;
    [Column(name: "password")] public string Password { get; set; } = string.Empty;
    [Column(name: "role_id")] public Guid RoleId { get; set; }
    
    public virtual Role Role { get; set; }
}