using Microsoft.AspNetCore.Mvc;
using TrackService.Application.Dtos;
using TrackService.Application.Dtos.Track;
using TrackService.Application.Interfaces;
using TrackService.Domain.Entities;

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
        var result = await tracksService.GetPopularAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TrackCreationDto track)
    {
        await tracksService.CreateAsync(track);
        
        return Created("api/tracks", track);
    }
    
    [HttpPut("play")]
    public async Task<IActionResult> Play(PlayTrackDto playTrackDto)
    {
        await tracksService.PlayAsync(playTrackDto);

        return NoContent();
    }
}