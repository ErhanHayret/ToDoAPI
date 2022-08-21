using Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public RoleEnum Role { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
