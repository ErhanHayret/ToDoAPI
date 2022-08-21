using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ToDoModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        public Guid? UserId { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public DateTime? AssignmentTime { get; set; }

        [NotMapped]
        public UserModel User { get; set; }

        [NotMapped]
        public UserModel CreatorUser { get; set; }
    }
}
