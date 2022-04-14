using System.Data;
using Dapper;
using Friend_Zone.Models;

namespace Friend_Zone.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;

    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Follow Create(Follow followData)
    {
      string sql = @"
      INSERT INTO follows
      (followingId, followerId)
      VALUES
      (@FollowingId, @FollowerId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, followData);
      followData.Id = id;
      return followData;
    }

    internal Follow Get(int id)
    {
      string sql = @"SELECT * FROM follows WHERE id = @id;";
      return _db.QueryFirstOrDefault<Follow>(sql, new { id });
    }

    internal Follow Get(string followerId, string followingId)
    {
      string sql = @"
      SELECT * FROM follows
      WHERE followingId = @followingId AND followerId = @followerId;
      ";
      return _db.QueryFirstOrDefault<Follow>(sql, new { followerId, followingId });
    }

    internal void Delete(int followId)
    {
      string sql = @"DELETE FROM follows WHERE id = @followId LIMIT 1";
      _db.Execute(sql, new { followId });
    }
  }
}