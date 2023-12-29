using SR.Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Entities.Concrete.DbModels
{
    public class Plan : BaseEntity
    {
        public string Description { get; set; }
        public int Cost { get; set; }
        public int MyProperty { get; set; }
    }
}
