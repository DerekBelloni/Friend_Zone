namespace Friend_Zone.Models
{

  public class Profile
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
  }

  public class FollowViewModel : Profile
  {
    public string FollowId { get; set; }


  }
}