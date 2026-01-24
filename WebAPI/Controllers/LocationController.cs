using Application.Common;
using Application.Features.ManageGoal.Queries.GetAll;
using Application.RealEstate.Queries;
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

    //[HttpGet("GetAveragePricePerSqFtQueryAPI")]
    //public Task<IActionResult> GetAveragePricePerSqFtQueryAPI([FromQuery] GetAveragePricePerSqFtQueryAPI query)
    //{
    //    return HandleRequest<GetAveragePricePerSqFtQueryAPI, double?>(query);
    //}
    #endregion
}
