using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalApi.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }
    }

    [Table("TableA")]
    public class TableARow
    {
        [Key]
        public int Id { get; set; }

        public double ColumnA { get; set; }
        public double ColumnB { get; set; }
        public double ColumnC { get; set; }
        public double ColumnD { get; set; }
        public double ColumnE { get; set; }
    }

    [Table("TableB")]
    public class TableBRow
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string ColumnA { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ColumnB { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ColumnC { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ColumnD { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ColumnE { get; set; } = string.Empty;
    }

    [Table("TableC")]
    public class TableCRow
    {
        [Key]
        public int Id { get; set; }

        public double ColumnA { get; set; }
        public double ColumnB { get; set; }
    }
}