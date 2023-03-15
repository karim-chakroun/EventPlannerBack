using System.Diagnostics.CodeAnalysis;

namespace EventPlanner.Domain.Models
{
    public class ApplicationUserModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        [AllowNull]
        public string? Role { get; set; }
        public string? Adresse { get; set; }
    }
}
