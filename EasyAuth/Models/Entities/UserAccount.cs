using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyAuth.Models.Entities
{
    [Table("users")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [MaxLength(128)]
        public string? UserName { get; set; }

        [Column("password")]
        [MaxLength(128)]
        public string? Password { get; set; }

        [Column("role")]
        [MaxLength(20)]
        public string? Role { get; set; }
    }
}
