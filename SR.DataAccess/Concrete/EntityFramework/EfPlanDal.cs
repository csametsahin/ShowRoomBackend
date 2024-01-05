using SR.Core.DataAccess.EntityFrameWork;
using SR.DataAccess.Abstract;
using SR.DataAccess.Concrete.Contexts;
using SR.Entities.Concrete.DbModels;

namespace SR.DataAccess.Concrete.EntityFramework
{
    public class EfPlanDal : EfEntityRepositoryBase<Plan, SRContext>, IPlanDal
    {
    }
}
