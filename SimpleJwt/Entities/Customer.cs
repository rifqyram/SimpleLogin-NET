using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJwt.Entities;

[Table(name: "m_customer")]
public class Customer
{
    [Key, Column(name: "id")] public Guid Id { get; set; }
    [Column(name: "name")] public string Name { get; set; } = string.Empty;
    [Column(name: "mobile_phone")] public string MobilePhone { get; set; } = string.Empty;
    [Column(name: "user_credential_id")] public Guid UserCredentialId { get; set; }

    public virtual UserCredential? UserCredential { get; set; }
}