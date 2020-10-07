using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRobo.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }
        public string TaskStatus { get; set; }
        [ForeignKey("EmailId")]
        public AppUser AppUser { get; set; }
        public string EmailId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
