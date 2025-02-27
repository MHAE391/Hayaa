using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Image : BaseEntity
    {
        public required string  ImageUrl { get; set; }
        [ForeignKey(nameof(Fax))]
        public int FaxId { get; set; }
        
        public virtual Fax Fax { get; set; }
    }
}
