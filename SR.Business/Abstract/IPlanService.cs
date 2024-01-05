using SR.Core.Utilities.Results;
using SR.Entities.Concrete.RequestModels.Plans;

namespace SR.Business.Abstract
{
    public interface IPlanService
    {
        Task<IResult> AddAsync(AddPlanRequestModel addPlanRequestModel);
    }
}
