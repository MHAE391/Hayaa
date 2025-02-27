using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Fax : BaseEntity
    {
        public string? Summary { get; set; }
        public required string FaxNumber { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public string? ViceManagerDecision { get; set; }
        public string? ManagerDecision { get; set; }
        public virtual IEnumerable<Image> Images { get; set; }
        [ForeignKey(nameof(Agency))]
        public int AgecyId { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual IEnumerable<FaxBranch> FaxBranches { get; set; }

    }
}
