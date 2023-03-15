using System.Collections.Generic;

namespace Vote.Models
{
  public class Choice
  {
    public int ChoiceId { get; set; }
    public int TopicId { get; set; }
    public string Description { get; set; }
    public int VoteCount { get; set; }
  
  }
}