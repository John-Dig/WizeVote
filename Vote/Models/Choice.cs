using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Vote.Models
{
  public class Choice
  {
    public int ChoiceId { get; set; }
    [Required(ErrorMessage = "The choice's description can't be empty!")]
    public string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add your Choice to a Topic.  Have you created a topic yet?")]
    public int TopicId { get; set; }
    public Topic Topic { get; set; }
    public int VoteCount { get; set; }
    public ApplicationUser User {get; set;}
  }
}