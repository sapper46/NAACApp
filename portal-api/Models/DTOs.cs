using System.ComponentModel.DataAnnotations;

namespace PortalApi.Models
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public UserDto? User { get; set; }
        public string? Message { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
    }

    public class ColumnSums
    {
        public double ColumnA { get; set; }
        public double ColumnB { get; set; }
        public double ColumnC { get; set; }
        public double ColumnD { get; set; }
        public double ColumnE { get; set; }
    }

    public class AnimalCount
    {
        public string Animal { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}