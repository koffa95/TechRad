using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class AuthorInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Url]
        public string ProfileImgSource { get; set; }
        [MaxLength(225)]
        public string Bio{ get; set; }
    }
}