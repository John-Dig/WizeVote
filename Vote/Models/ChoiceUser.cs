namespace Vote.Models
{
  public class ChoiceUser
    {       
        public int ChoiceUserId { get; set; }
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
