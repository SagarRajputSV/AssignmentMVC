using FormFactory.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    public class AppUser
    {
        [Key]
        public string EmailId { get; set; }
     
        [Password]
        public string Password { get; set; }
    }
}
