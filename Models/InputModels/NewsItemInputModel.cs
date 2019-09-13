using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class NewsItemInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Url]
        public string ImgSource { get; set; }
        [Required]
        [Range(1,50)]
        public string ShortDescription{ get; set; }
        [MinLength(50)]
        [MaxLength(225)]
        public string LongDescription{ get; set; }
        [Required]
        public System.DateTime PublishDate{get; set;}
    }
}