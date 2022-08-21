using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class ToDoDto
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public string? UserId { get; set; }

        public DateTime? CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public DateTime? AssignmentTime { get; set; }
    }
}
