using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Entities.Concrete.RequestModels.Plans
{
    public class AddPlanRequestModel
    {
        public string Description { get; set; }
        public int Cost { get; set; }
        public string CreatedBy { get; set; }
    }
}
