using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanSite.EntityFramework.Services.Entities
{
    [Table("media_series")]
    public class MediaSeriesDto
    {
        public MediaSeriesDto()
        {
            MediaCollection = new HashSet<MediaDto>();
        }

        [Key]
        [Column("ms_id", TypeName = "tinyint", Order = 1)]
        public byte Id { get; set; }

        [Required]
        [Column("ms_title", TypeName = "ntext", Order = 2)]
        public string Title { get; set; }

        [InverseProperty("Series")]
        public virtual ICollection<MediaDto> MediaCollection { get; set; }
    }
}
