using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Entities
{
    [Table("user")]
    [Index(nameof(Email), Name = "IX_email")]
    [Index(nameof(RoleId), Name = "IX_role_id")]
    public class UserDto
    {
        [Key]
        [Column("us_id", TypeName = "int", Order = 1)]
        public int Id { get; set; }

        [Required]
        [Column("us_name", TypeName = "nvarchar", Order = 2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Column("us_password", TypeName = "nvarchar", Order = 3)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("us_email", TypeName = "nvarchar", Order = 4)]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [Column("us_role", TypeName = "tinyint", Order = 5)]
        [ForeignKey("Role")]
        public byte RoleId { get; set; }

        public virtual RoleDto Role { get; set; }
    }
}
