using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FanSiteService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Entities
{
    [Table("media")]
    [Index(nameof(TypeId), Name = "IX_type_id")]
    [Index(nameof(SeriesId), Name = "IX_series_id")]
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

        [Required]
        [Column("md_rating", TypeName = "float", Order = 5)]
        public double Rating { get; set; }

        [Required]
        [Column("md_is_upcoming", TypeName = "bit", Order = 6)]
        public bool IsUpcoming { get; set; }

        [Column("md_type", TypeName = "tinyint", Order = 7)]
        [ForeignKey("Type")]
        public byte TypeId { get; set; }

        [Column("md_series_id", TypeName = "tinyint", Order = 8)]
        [ForeignKey("Series")]
        public int SeriesId { get; set; }

        public virtual MediaTypeDto Type { get; set; }
        public virtual MediaSeriesDto Series { get; set; }
    }
}
