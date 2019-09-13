using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models;
using Models.DTO;
using Models.Entities;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepo
    {
        private IMapper _mapper;

        public NewsRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Author> GetAuthorsByNewsItemId(int id)
        {
            var authors = (from auth in DataProvider.Authors
                                 join newsauthors in DataProvider.NewsItemAuthors on auth.Id equals newsauthors.AuthorId
                                 join news in DataProvider.NewsItems on newsauthors.NewsItemId equals news.Id
                                 where news.Id == id
                                 select auth).ToList();
            return authors;
        }

        public List<Category> GetCategoriesByNewsItemId(int id)
        {
            var categories = (from c in DataProvider.Categories
                                 join newscategories in DataProvider.NewsItemCategories on c.Id equals newscategories.CategoryId
                                 join news in DataProvider.NewsItems on newscategories.NewsItemId equals news.Id
                                 where news.Id == id
                                 select c).ToList();
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
            //var entity = _mapper.Map<NewsItem>(news);
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
            // return _mapper.Map<NewsItemDto>(entity);
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

            //Update properties
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
            if (entity == null) { return; /*Throw exception */}
            DataProvider.NewsItems.Remove(entity);
        }
    }
}
