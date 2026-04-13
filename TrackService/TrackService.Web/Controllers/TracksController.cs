using Microsoft.AspNetCore.Mvc;
using TrackService.Application.Interfaces;

namespace TrackService.Web.Controllers;

[ApiController]
[Route("/api/tracks")]
public class TracksController(ITracksService tracksService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await tracksService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("popular")]
    public async Task<IActionResult> GetPopular()
    {
        var result = await tracksService.GetPopular();

        return Ok(result);
    }
}