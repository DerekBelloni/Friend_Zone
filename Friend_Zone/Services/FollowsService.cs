using System;
using Friend_Zone.Models;
using Friend_Zone.Repositories;

namespace Friend_Zone.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository _fRepo;

    public FollowsService(FollowsRepository fRepo)
    {
      _fRepo = fRepo;
    }

    private Follow Get(int id)
    {
      Follow found = _fRepo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Follow Create(Follow followData)
    {
      Follow exists = _fRepo.Get(followData.followerId, followData.followingId);
      if (exists != null)
      {
        return exists;
      }
      return _fRepo.Create(followData);
    }

    internal void Delete(int followId, string userId)
    {
      Follow found = Get(followId);
      if (found.followerId != userId)
      {
        throw new Exception("Can not delete");
      }
      _fRepo.Delete(followId);
    }
  }
}