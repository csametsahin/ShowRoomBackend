using SR.Core.DataAccess;
using SR.Entities.Concrete.DbModels;

namespace SR.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
