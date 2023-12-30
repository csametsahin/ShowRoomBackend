using SR.Core.Utilities.Results;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> AddAsync(UserRegisterRequsetModel userRequestModel);
    }
}
