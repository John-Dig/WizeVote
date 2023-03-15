using Microsoft.EntityFrameworkCore;

namespace Vote.Models
{
  public class VoteContext : DbContext
  {
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ChoiceUser> ChoiceUsers { get; set; }

    public VoteContext(DbContextOptions options) : base(options) { }
  }
}
