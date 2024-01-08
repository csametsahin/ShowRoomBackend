using Microsoft.AspNetCore.Http;
using Serilog;
using SR.Business.Abstract;
using SR.Core.Utilities.Localization;
using SR.Core.Utilities.Messages;
using SR.Core.Utilities.Results;
using SR.DataAccess.Abstract;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Plans;
using SR.Entities.Enums;
using IResult = SR.Core.Utilities.Results.IResult;

namespace SR.Business.Concrete
{
    public class PlanManager : IPlanService
    {
        #region DIs
        private readonly IPlanDal _planDal;

        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;
        public PlanManager(IPlanDal planDal,ILocalizationService localizationService,ILogger logger)
        {
            _planDal = planDal;
            _localizationService = localizationService;
            _logger = logger;
        }
        #endregion

        public async Task<IResult> AddAsync(AddPlanRequestModel addPlanRequestModel)
        {
            try
            {
                var model = new Plan
                {
                    Cost = addPlanRequestModel.Cost,
                    Description = addPlanRequestModel.Description,
                    CreatedBy = addPlanRequestModel.CreatedBy
                };
                var result = _planDal.AddAsync(model);
                if (result != null)
                    return new SuccessResult(_localizationService[MessageCodes.PlanAddedSuccessfully], StatusCodes.Status200OK);

                _logger.Error("Error while executing AddAsync on PlanManager");
                return new ErrorResult(_localizationService[MessageCodes.ErrorWhileAddingPlan], StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                //TODO logging will be adeded , payment will be aded
                _logger.Error($"Error thrown in AddAsync on PlanManager Error - {ex} ");
                return new ErrorResult(_localizationService[MessageCodes.ErrorWhileAddingPlan], StatusCodes.Status500InternalServerError);
            }
        }
    }
}
