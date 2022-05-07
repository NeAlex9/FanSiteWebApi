using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanSite.EntityFramework.Services.Entities
{
    [Table("role")]
    public class RoleDto
    {
        public RoleDto()
        {
            Users = new HashSet<UserDto>();
        }

        [Key]
        [Column("rl_id", TypeName = "tinyint", Order = 1)]
        public byte Id { get; set; }

        [Required]
        [Column("rl_name", TypeName = "nvarchar", Order = 2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<UserDto> Users { get; set; }
    }
}
