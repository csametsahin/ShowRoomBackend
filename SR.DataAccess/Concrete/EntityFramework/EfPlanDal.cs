using SR.Core.DataAccess.EntityFrameWork;
using SR.DataAccess.Abstract;
using SR.DataAccess.Concrete.Contexts;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Concrete.EntityFramework
{
    public class EfPlanDal : EfEntityRepositoryBase<Plan,SRContext> , IPlanDal
    {
    }
}
