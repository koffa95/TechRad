using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(60)]
        public string Name {get; set;}
    }
}