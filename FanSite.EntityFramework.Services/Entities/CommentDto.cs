using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainEntities;

namespace FanSiteService.Entities
{
    [Table("comment")]
    public class CommentDto
    {
        [Column("cm_id", TypeName = "int", Order = 1)]
        public int Id { get; set; }

        [Column("cm_text", TypeName = "ntext", Order = 2)]
        [Required]
        public string Text { get; set; }

        [Column("cm_publication_date", TypeName = "datetime", Order = 3)]
        [Required]
        public DateTime PublicationDate { get; set; }

        [Column("cm_media_id", TypeName = "int", Order = 4)]
        [ForeignKey("Media")]
        public int MediaId { get; set; }

        [Column("cm_user_id", TypeName = "int", Order = 5)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual MediaDto Media { get; set; }
        public virtual User User { get; set; }
    }
}
