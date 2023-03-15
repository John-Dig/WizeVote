using System.Collections.Generic;

namespace Vote.Models
{
  public class User
  {
    public string Name { get; set; }
    public int UserId { get; set; }
    public List<OptionUser> JoinEntities { get; }
    //public List<TopicOption> JoinEntities { get; } //collection navigation property
  }
}