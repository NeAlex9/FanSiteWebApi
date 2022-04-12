using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace FanSiteService.Entities
{
    [Table("user")]
    public class UserDto
    {
        [Key]
        [Column("us_id", TypeName = "int", Order = 1)]
        public int Id { get; set; }

        [Required]
        [Column("us_first_name", TypeName = "nvarchar", Order = 2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Column("us_second_name", TypeName = "nvarchar", Order = 3)]
        [MaxLength(20)]
        public string SecondName { get; set; }

        [Required]
        [Column("us_password", TypeName = "nvarchar", Order = 4)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("us_email", TypeName = "nvarchar", Order = 5)]
        [MaxLength(30)]
        public string Email { get; set; }

        [Column("us_role", TypeName = "int", Order = 6)]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
