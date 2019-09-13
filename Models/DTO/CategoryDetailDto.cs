using TechnicalRadiation.Models;

namespace Models.DTO
{
    public class CategoryDetailDto : HyperMediaModel
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Slug { get; set;} //string??????????
        public int NumberofNewsItems { get; set;}
    }
}