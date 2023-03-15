﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string? FullName { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public string? Adresse { get; set; }
    }
}
