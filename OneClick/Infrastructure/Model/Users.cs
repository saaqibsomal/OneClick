﻿using System.ComponentModel.DataAnnotations;

namespace OneClick.Infrastructure.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
        public bool? IsActive { get; set; } 
        public bool? Deleted { get; set; } 
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}
