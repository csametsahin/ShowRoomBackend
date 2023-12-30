using SR.DataAccess.Abstract;
using SR.DataAccess.Concrete.Contexts;
using SR.Core.DataAccess;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Core.DataAccess.EntityFrameWork;

namespace SR.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SRContext>, IUserDal
    {
    }
}
