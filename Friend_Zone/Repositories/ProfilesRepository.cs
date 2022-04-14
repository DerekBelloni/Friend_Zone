using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Friend_Zone.Models;

namespace Friend_Zone.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;
    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Profile> GetAll()
    {
      string sql = @"
      SELECT * FROM accounts;
      ";
      return _db.Query<Profile>(sql).ToList();
    }

    internal Profile GetById(string id)
    {
      string sql = @"
      SELECT a.*
      FROM accounts a
      WHERE a.id = @id;
      ";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal List<FollowViewModel> GetFollowing(string id)
    {
      string sql = @"
      SELECT
      f.id AS FollowId,
      a.*
      FROM follows f
      JOIN accounts a ON a.id = f.followingId
      WHERE f.followerId = @id;
      ";
      return _db.Query<FollowViewModel>(sql, new { id }).ToList();
    }

    internal List<FollowViewModel> GetFollowers(string id)
    {
      string sql = @"
      SELECT 
      f.id AS FollowId,
      a.*
      FROM follows f
      JOIN accounts a ON a.id = f.followerId
      WHERE f.followingId = @id;
      ";
      return _db.Query<FollowViewModel>(sql, new { id }).ToList();
    }
  }
}
