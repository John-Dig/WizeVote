using System.Collections.Generic;

namespace Vote.Models
{
  public class Option
  {
    public int OptionId { get; set; }
    public int TopicId { get; set; }
    public string Description { get; set; }
  
  }
}