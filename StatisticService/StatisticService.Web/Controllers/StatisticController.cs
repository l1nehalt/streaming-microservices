using Microsoft.AspNetCore.Mvc;
using StatisticService.Application.Dtos;
using StatisticService.Application.Interfaces;
using StatisticService.Domain.Entities;

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

    [HttpPut("increase-playcount")]
    public async Task<IActionResult> IncreasePlayCount(StatisticIncreasingDto statistic)
    {
        await statisticService.IncreasePlayCount(statistic);
        
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(StatisticCreationDto statistic)
    {
        await statisticService.Create(statistic);

        return Created("api/statistics", statistic);
    }
}