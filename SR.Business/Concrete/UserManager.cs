using AutoMapper;
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
using SR.Entities.Concrete.ViewModels.User;
using SR.Entities.Enums;

namespace SR.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;


        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        #region DIs
        public UserManager(IUserDal userDal, ILocalizationService localizationService, IMapper mapper)
        {
            _userDal = userDal;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        #endregion

        public async Task<IDataResult<UserViewModel>> RegisterAsync(UserRegisterRequsetModel userRequestModel)
        {
            try
            {
                var isUserExist = _userDal.CheckIfExists(_ => _.MailAddress == userRequestModel.MailAddress);
                if (isUserExist)
                    return new ErrorDataResult<UserViewModel>(_localizationService[MessageCodes.ErrorWhileAddingUserEmailAlreadyExists], StatusCodes.Status401Unauthorized);
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

                var user = await _userDal.AddAsync(userToAdd);
                if (user != null)
                    return new SuccessDataResult<UserViewModel>(_mapper.Map<UserViewModel>(user), _localizationService[MessageCodes.UserRegisteredSuccessfully], StatusCodes.Status201Created);

                return new ErrorDataResult<UserViewModel>(_localizationService[MessageCodes.ErrorWhileAddingUser], StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserViewModel>(_localizationService[MessageCodes.ErrorWhileAddingUser], StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IDataResult<UserViewModel>> LoginAsync(UserLoginRequestModel userLoginRequestModel)
        {
            try
            {
                var model = await _userDal.GetAsync(_ => _.MailAddress == userLoginRequestModel.MailAddress);
                if (model == null)
                    return new ErrorDataResult<UserViewModel>(_localizationService[MessageCodes.UserNotFound], StatusCodes.Status500InternalServerError);
                var passCheck = CryptographyHelper.VerifyPassword(userLoginRequestModel.Password, model.Password);
                if (!passCheck)
                    return new ErrorDataResult<UserViewModel>(_localizationService[MessageCodes.PasswordError], StatusCodes.Status500InternalServerError);

                return new SuccessDataResult<UserViewModel>(_mapper.Map<UserViewModel>(model), _localizationService[MessageCodes.UserLoggedInSuccessfully], StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserViewModel>(_localizationService[MessageCodes.ErrorWhileLoginUserAsync], StatusCodes.Status500InternalServerError);
            }
        }
    }
}
