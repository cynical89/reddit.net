using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Reddit.net.Models
{
    public class UserModel : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public int Reputation { get; set; }
    }
}

