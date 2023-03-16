using System.Collections.Generic;

namespace Vote.Models
{
  public class User
  {
    public string Name { get; set; }
    public int UserId { get; set; }
    public List<ChoiceUser> JoinEntities { get;}
  }
}