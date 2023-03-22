using Microsoft.AspNetCore.Identity;
using System;

namespace Vote.Models
{
    public class ApplicationUser : IdentityUser
    {
      public string Website { get; set; }
      public string Image { get; set; }
    }
}