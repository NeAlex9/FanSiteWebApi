using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using FanSite.EntityFramework.Services.Entities;

namespace FanSiteService.Entities
{
    [Table("media_type")]
    public class MediaTypeDto
    {
        public MediaTypeDto()
        {
            Media = new HashSet<MediaDto>();
        }

        [Key]
        [Column("mt_id", TypeName = "tinyint", Order = 1)]
        public byte Id { get; set; }

        [Required]
        [Column("mt_name", TypeName = "nvarchar", Order = 2)]
        [MaxLength(15)]
        public string Name { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<MediaDto> Media { get; set; }
    }
}
