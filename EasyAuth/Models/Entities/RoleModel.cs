using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyAuth.Models.Entities
{
    [Table("roles")]
    public class RoleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("role")]
        [MaxLength(128)]
        public required string Role { get; set; }
    }
    
}
