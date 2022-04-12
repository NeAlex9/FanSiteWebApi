using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSiteService.Entities
{
    [Table("media")]
    public class MediaDto
    {
        [Key]
        [Column("md_id", TypeName = "int", Order = 1)]
        public int Id { get; set; }

        [Required]
        [Column("md_title", TypeName = "nvarchar", Order = 2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Column("md_publication_date", TypeName = "datetime", Order = 3)]
        public DateTime? PublicationDate { get; set; }

        [Required]
        [Column("md_description", TypeName = "ntext", Order = 4)]
        public string Description { get; set; }

        [Column("md_rating", TypeName = "float", Order = 5)]
        public double Rating { get; set; }

        [Column("md_is_upcoming", TypeName = "bit", Order = 7)]
        public bool IsUpcoming { get; set; }

        [Column("md_type", TypeName = "tinyint", Order = 6)]
        [ForeignKey("Type")]
        public byte TypeId { get; set; }

        [Column("md_series_id", TypeName = "tinyint", Order = 7)]
        [ForeignKey("Series")]
        public int SeriesId { get; set; }

        public virtual MediaTypeDto Type { get; set; }
        public virtual MediaSeriesDto Series { get; set; }
    }
}
