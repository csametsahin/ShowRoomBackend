using SR.Core.DataAccess;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Abstract
{
    public interface IShowRoomDal : IEntityRepository<ShowRoom>
    {
    }
}
