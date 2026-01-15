using Application.Common;
using Application.Features.ManageGoal.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

[ApiController]
public class ActivityController : BaseControllerAPI
{
    #region Listing
    [HttpGet("GetAllActivity")]
    public Task<IActionResult> GetAllActivity()
    {
        return HandleRequest<GetAllActivitySelectedListQueryAPI, List<SelectedList>>(
            new GetAllActivitySelectedListQueryAPI());
    }

    [HttpGet("GetAllActivityCategoryByActivityId")]
    public Task<IActionResult> GetAllActivityCategoryByActivityId([FromQuery] GetAllActivityCategoryByActivityIdSelectedListQueryAPI query)
    {
        return HandleRequest<GetAllActivityCategoryByActivityIdSelectedListQueryAPI, List<SelectedList>>(query);
    }
    #endregion
}
