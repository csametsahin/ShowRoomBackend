using SR.Core.Utilities.Results;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Users;

namespace SR.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> RegisterAsync(UserRegisterRequsetModel userRequestModel);
    }
}
