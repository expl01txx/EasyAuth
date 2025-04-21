using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyAuth.Models.Entities
{
    [Table("tokens")]
    public class TokenModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("owner_username")]
        [MaxLength(128)]
        public required string OwnerUsername { get; set; }

        [Column("token")]
        [MaxLength(128)]
        public required string Token { get; set; }

        [Column("role")]
        [MaxLength(32)]
        public required string Role { get; set; }

        [Column("expire")]
        public DateTime Expires { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("is_freezed")]
        public bool IsFreezed { get; set; }

        [Column("hwid")]
        [MaxLength(128)]
        public string? Hwid { get; set; } // Добавлено свойство HWID, nullable
    }
}