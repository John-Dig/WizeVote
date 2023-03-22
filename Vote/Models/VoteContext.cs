using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vote.Models
{
  public class VoteContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Choice> Choices { get; set; }
  

    public VoteContext(DbContextOptions options) : base(options) { }
  }
}
