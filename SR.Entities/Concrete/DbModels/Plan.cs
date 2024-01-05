using SR.Entities.Concrete.BaseEntities;

namespace SR.Entities.Concrete.DbModels
{
    public class Plan : BaseEntity
    {
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
