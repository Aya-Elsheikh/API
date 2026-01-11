using Application.Common;
using Application.Features.ManageGoal.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

[ApiController]
public class LocationController : BaseControllerAPI
{
    #region Listing
    [HttpGet("GetSectors")]
    public Task<IActionResult> GetSectors()
    {
        return HandleRequest<GetAllSectorsSelectedListQueryAPI, List<SelectedList>>(
            new GetAllSectorsSelectedListQueryAPI());
    }

    [HttpGet("GetCommunityBySectorId")]
    public Task<IActionResult> GetCommunityBySectorId([FromQuery] GetAllCommunityBySectorIdSelectedListQueryAPI query)
    {
        return HandleRequest<GetAllCommunityBySectorIdSelectedListQueryAPI, List<SelectedList>>(query);
    }
    #endregion
}
