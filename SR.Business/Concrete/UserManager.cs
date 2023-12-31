using Microsoft.AspNetCore.Http;
using SR.Business.Abstract;
using SR.Core.Utilities.Helpers;
using SR.Core.Utilities.Messages;
using SR.Core.Utilities.Results;
using SR.DataAccess.Abstract;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Users;
using SR.Entities.Concrete.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        

        #region DIs
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        #endregion

        public async Task<IDataResult<User>> AddAsync(UserRegisterRequsetModel userRequestModel)
        {
            try
            {
                var isUserExist = _userDal.CheckIfExists(_ => _.MailAddress == userRequestModel.MailAddress);
                if (isUserExist)
                    return new ErrorDataResult<User>(Messages.ErrorWhileAddingUserEmailAlreadyExists, StatusCodes.Status401Unauthorized);
                var userToAdd = new User
                {
                    Name = userRequestModel.Name,
                    Surname = userRequestModel.Surname,
                    MailAddress = userRequestModel.MailAddress,
                    Password = CryptographyHelper.HashPassword(userRequestModel.Password),
                    CreatedBy = userRequestModel.MailAddress,
                    SubscriptionEndDate = userRequestModel.SubscriptionEndDate,
                    IsPaymentGranted = userRequestModel.IsPaymentGranted,
                    IsMailApproved = userRequestModel.IsMailApproved,
                };
                // TODO : Either remove this user return type or change it to UserViewModel 
                // we will not be returning dbmodels
                var user = await _userDal.AddAsync(userToAdd);
                if (user != null)
                    return new SuccessDataResult<User>(user, Messages.UserRegisteredSuccessfully, StatusCodes.Status201Created);

                return new ErrorDataResult<User>(Messages.ErrorWhileAddingUser, StatusCodes.Status500InternalServerError);
            }
            catch(Exception ex)
            {
                return new ErrorDataResult<User>(Messages.ErrorWhileAddingUser, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
