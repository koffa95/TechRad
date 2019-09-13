using TechnicalRadiation.Models;

namespace Models.DTO
{
    public class AuthorDetailDto : HyperMediaModel
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string ProfileImgSource { get; set;}
        public string ShortDescription { get; set;}
    }
}