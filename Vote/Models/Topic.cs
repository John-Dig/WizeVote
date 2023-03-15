using System.Collections.Generic;

namespace Vote.Models
{
  public class Topic
  {
    public int TopicId { get; set; }
    public string Name { get; set; }
    public List<Choice> Choices { get; set; }
  }
}