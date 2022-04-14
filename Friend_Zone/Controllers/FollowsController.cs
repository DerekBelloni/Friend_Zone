using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Friend_Zone.Models;
using Friend_Zone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Friend_Zone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class FollowsController : ControllerBase

  {
    private readonly FollowsService _followsService;

    public FollowsController(FollowsService followsService)
    {
      _followsService = followsService;
    }

    [HttpPost]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        followData.followerId = user.Id;
        Follow created = _followsService.Create(followData);
        return Ok(created);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        _followsService.Delete(id, user.Id);
        return Ok("Deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}