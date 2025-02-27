
namespace Database.Entities
{
    public class Branch : BaseEntity
    {
        public required string Name { get; set; }
        public virtual IEnumerable<FaxBranch> BrachFaxes {  get; set; } 
    }
}
