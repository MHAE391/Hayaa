
namespace Database.Entities
{ 
    public class Agency : BaseEntity
    {
        public required  string Name { get; set; }
        public virtual IEnumerable<Fax> Faxes { get; set; }
    }
}
