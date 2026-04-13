using Microsoft.AspNetCore.Mvc;
using StatisticService.Application.Interfaces;

namespace StatisticService.Web.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticController(IStatisticService statisticService) : ControllerBase
{
    [HttpGet("popular")]
    public async Task<IActionResult> GetPopular()
    {
        var result = await statisticService.GetPopular();
        
        return Ok(result);
    }
}