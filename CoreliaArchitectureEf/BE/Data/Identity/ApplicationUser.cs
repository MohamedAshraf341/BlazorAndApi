using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BE.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
