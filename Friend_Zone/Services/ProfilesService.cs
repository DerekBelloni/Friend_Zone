using System.Collections.Generic;
using Friend_Zone.Models;
using Friend_Zone.Repositories;

namespace Friend_Zone.Services
{
  public class ProfilesService
  {

    private readonly ProfilesRepository _pRepo;
    public ProfilesService(ProfilesRepository pRepo)
    {
      _pRepo = pRepo;
    }

    internal List<Profile> GetAll()
    {
      return _pRepo.GetAll();
    }

    internal Profile GetById(string id)
    {
      return _pRepo.GetById(id);
    }

    internal List<FollowViewModel> GetFollowers(string id)
    {
      return _pRepo.GetFollowers(id);
    }

    internal List<FollowViewModel> GetFollowing(string id)
    {
      return _pRepo.GetFollowing(id);
    }
  }
}