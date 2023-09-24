using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace BE.Data.Identity
{
    [Owned]
    public class RefreshToken
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime ExpiresOn { get; set; }
        [Required]
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        [Required]
        public bool IsActive => RevokedOn == null && !IsExpired;
    }
}
