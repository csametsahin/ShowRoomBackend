﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SR.Business.Abstract;
using SR.Core.Utilities.Messages;
using SR.Entities.Concrete.RequestModels.Plans;
using IResult = SR.Core.Utilities.Results.IResult;

namespace SR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        [HttpPost("AddPlan")]
        [ProducesResponseType(typeof(IResult), 200)]
        [Authorize]
        public async Task<IActionResult> AddPlan([FromBody] AddPlanRequestModel addPlanRequestModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status406NotAcceptable, Messages.ModelError);

            var result = await _planService.AddAsync(addPlanRequestModel);
            return StatusCode(result.Code, result.Message);
        }
    }
}
