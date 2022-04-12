using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSiteService.Entities
{
    [Table("media_series")]
    public class MediaSeriesDto
    {
        [Key]
        [Column("ms_id", TypeName = "int", Order = 1)]
        public int Id { get; set; }

        [Required]
        [Column("ms_title", TypeName = "ntext", Order = 2)]
        public string Title { get; set; }

        [InverseProperty("Series")]
        public virtual ICollection<MediaDto> MediaCollection { get; set; }
    }
}
