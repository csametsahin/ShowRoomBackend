using Microsoft.AspNetCore.Http;
using SR.Business.Abstract;
using SR.Business.Utilities.Constants;
using SR.Core.Utilities.Helpers;
using SR.Core.Utilities.Localization;
using SR.Core.Utilities.Messages;
using SR.Core.Utilities.Results;
using SR.DataAccess.Abstract;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Users;
using SR.Entities.Enums;

namespace SR.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;


        private readonly ILocalizationService _localizationService;

        #region DIs
        public UserManager(IUserDal userDal, ILocalizationService localizationService)
        {
            _userDal = userDal;
            _localizationService = localizationService;
        }
        #endregion

        public async Task<IDataResult<User>> RegisterAsync(UserRegisterRequsetModel userRequestModel)
        {
            try
            {
                var isUserExist = _userDal.CheckIfExists(_ => _.MailAddress == userRequestModel.MailAddress);
                if (isUserExist)
                    return new ErrorDataResult<User>(_localizationService[MessageCodes.ErrorWhileAddingUserEmailAlreadyExists], StatusCodes.Status401Unauthorized);
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
                    PlanId = PlanConstants.EmptyPlanId,
                };
                // TODO : Either remove this user return type or change it to UserViewModel 
                // we will not be returning dbmodels
                var user = await _userDal.AddAsync(userToAdd);
                if (user != null)
                    return new SuccessDataResult<User>(user, Messages.UserRegisteredSuccessfully, StatusCodes.Status201Created);

                return new ErrorDataResult<User>(Messages.ErrorWhileAddingUser, StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(Messages.ErrorWhileAddingUser, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
