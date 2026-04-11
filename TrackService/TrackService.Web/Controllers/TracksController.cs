using Microsoft.AspNetCore.Mvc;
using TrackService.Application.Interfaces;

namespace TrackService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TracksController(ITracksService tracksService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await tracksService.GetAllAsync();

        return Ok(result);
    }
}
