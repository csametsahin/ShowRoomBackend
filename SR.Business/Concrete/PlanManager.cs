using Microsoft.AspNetCore.Http;
using SR.Business.Abstract;
using SR.Core.Utilities.Messages;
using SR.Core.Utilities.Results;
using SR.DataAccess.Abstract;
using SR.DataAccess.Concrete.EntityFramework;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = SR.Core.Utilities.Results.IResult;

namespace SR.Business.Concrete
{
    public class PlanManager : IPlanService
    {
        #region DIs
        private readonly IPlanDal _planDal;
        public PlanManager(IPlanDal planDal)
        {
            _planDal = planDal;
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
                    return new SuccessResult(Messages.PlanAddedSuccessfully, StatusCodes.Status200OK);
                return new ErrorResult(Messages.ErrorWhileAddingPlan,StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                //TODO loggin will be adeded , payment will be aded
                return new ErrorResult(Messages.ErrorWhileAddingPlan, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
