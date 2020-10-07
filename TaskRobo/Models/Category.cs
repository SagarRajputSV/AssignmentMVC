using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRobo.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryTitle { get; set; }
        [ForeignKey("EmailId")]
        public AppUser AppUser { get; set; }
        public string EmailId { get; set; }
    }
}
