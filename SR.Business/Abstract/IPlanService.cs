using SR.Core.Utilities.Results;
using SR.Entities.Concrete.RequestModels.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Business.Abstract
{
    public interface IPlanService
    {
        Task<IResult> AddAsync(AddPlanRequestModel addPlanRequestModel);
    }
}
