using System;

namespace Friend_Zone.Models
{
  public class Follow
  {
    public int Id { get; set; }

    public string followingId { get; set; }

    public string followerId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


  }
}