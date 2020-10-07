using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    public class AppUser
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
