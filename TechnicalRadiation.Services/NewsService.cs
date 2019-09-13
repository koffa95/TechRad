using System.Collections.Generic;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using TechnicalRadiation.Models.Extensions;
using System.Linq;

namespace TechnicalRadiation.Services
{
    public class NewsService
    {
        private NewsRepository _newsRepo;

        public NewsService(IMapper mapper)
        {
            _newsRepo = new NewsRepository(mapper);
        }

        public List<NewsItemDto> GetAllNews()
        {
            var news = _newsRepo.GetAllNews();
            foreach (var n in news)
            {
                n.Links.AddReference("self", $"api/{n.Id}");
                n.Links.AddReference("edit", $"api/{n.Id}");
                n.Links.AddReference("delete", $"api/{n.Id}");
                n.Links.AddListReference("authors", _newsRepo.GetAuthorsByNewsItemId(n.Id)
                    .Select(a => new { href = $"api/authors/{a.Id}" }));
                n.Links.AddListReference("categories", _newsRepo.GetCategoriesByNewsItemId(n.Id)
                    .Select(c => new { href = $"api/categories/{c.Id}" }));
            }
            return news;
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            var news = _newsRepo.GetNewsById(id);
            news.Links.AddReference("self", $"api/{news.Id}");
            news.Links.AddReference("edit", $"api/{news.Id}");
            news.Links.AddReference("delete", $"api/{news.Id}");
            news.Links.AddListReference("authors", _newsRepo.GetAuthorsByNewsItemId(news.Id)
                .Select(a => new { href = $"api/authors/{a.Id}" }));
            news.Links.AddListReference("categories", _newsRepo.GetCategoriesByNewsItemId(news.Id)
                .Select(c => new { href = $"api/categories/{c.Id}" }));
            return news;
        }

        public NewsItemDto CreateNews(NewsItemInputModel news)
        {
            return _newsRepo.CreateNews(news);
        }

        public void UpdateNewsById(NewsItemInputModel news, int id)
        {
            _newsRepo.UpdateNewsById(news, id);
        }

        public void DeleteNewsById(int id)
        {
            _newsRepo.DeleteNewsById(id);
        }
    }
}