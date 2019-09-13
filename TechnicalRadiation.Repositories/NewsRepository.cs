using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepository
    {
        private IMapper _mapper;

        public NewsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Author> GetAuthorsByNewsItemId(int id)
        {
            var authors = (from auther in DataProvider.Authors
                                 join newsAuthors in DataProvider.NewsItemAuthors on auther.Id equals newsAuthors.AuthorId
                                 join news in DataProvider.NewsItems on newsAuthors.NewsItemId equals news.Id
                                 where news.Id == id
                                 select auther).ToList();
            return authors;
        }

        public List<Category> GetCategoriesByNewsItemId(int id)
        {
            var categories = (from cat in DataProvider.Categories
                                 join newsICat in DataProvider.NewsItemCategories on cat.Id equals newsICat.CategoryId
                                 join news in DataProvider.NewsItems on newsICat.NewsItemId equals news.Id
                                 where news.Id == id
                                 select cat).ToList();
            return categories;
        }
        
        public List<NewsItemDto> GetAllNews()
        {
            return _mapper.Map<List<NewsItemDto>>(DataProvider.NewsItems);
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            return _mapper.Map<NewsItemDetailsDto>(DataProvider.NewsItems.Where(n => n.Id == id).SingleOrDefault());
        }

        public NewsItemDto CreateNews(NewsItemInputModel news)
        {
            var nextId = DataProvider.NewsItems.OrderByDescending(n => n.Id).FirstOrDefault().Id + 1;
            var entity = new NewsItem
            {
                Id = nextId,
                Title = news.Title,
                ImgSource = news.ImgSource,
                ShortDescription = news.ShortDescription,
                LongDescription = news.LongDescription,
                PublishDate = news.PublishDate,
                ModifiedBy = "TechnicalRadiationAdmin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            DataProvider.NewsItems.Add(entity);
            return new NewsItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ImgSource = entity.ImgSource,
                ShortDescription = entity.ShortDescription
            };
        }
        public void UpdateNewsById(NewsItemInputModel news, int id)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(n => n.Id == id);

            entity.Title = news.Title;
            entity.ImgSource = news.ImgSource;
            entity.ShortDescription = news.ShortDescription;
            entity.LongDescription = news.LongDescription;
            entity.PublishDate = news.PublishDate;
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "TechnicalRadiationAdmin";
        }

        public void DeleteNewsById(int id)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(n => n.Id == id);
            if (entity == null) 
            { 
                return; 
            } //exception thrown
            DataProvider.NewsItems.Remove(entity);
        }
    }
}