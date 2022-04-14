using System.Collections.Generic;
using Friend_Zone.Models;
using Friend_Zone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Friend_Zone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;

    public ProfilesController(ProfilesService profilesService)
    {
      _profilesService = profilesService;
    }

    [HttpGet]
    public ActionResult<List<Profile>> GetAll()
    {
      try
      {
        List<Profile> profiles = _profilesService.GetAll();
        return Ok(profiles);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(string id)
    {
      try
      {
        Profile profile = _profilesService.GetById(id);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/followers")]
    public ActionResult<List<FollowViewModel>> Get(string id)
    {
      try
      {
        List<FollowViewModel> followers = _profilesService.GetFollowers(id);
        return Ok(followers);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/following")]
    public ActionResult<List<FollowViewModel>> GetFollowing(string id)
    {
      try
      {
        List<FollowViewModel> following = _profilesService.GetFollowing(id);
        return Ok(following);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }

  }
}
