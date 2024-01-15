using SR.Core.Utilities.Results;
using SR.Entities.Concrete.RequestModels.Users;
using SR.Entities.Concrete.ViewModels.User;

namespace SR.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserViewModel>> RegisterAsync(UserRegisterRequsetModel userRequestModel);
        Task<IDataResult<UserViewModel>> LoginAsync(UserLoginRequestModel userLoginRequestModel);
    }
}
