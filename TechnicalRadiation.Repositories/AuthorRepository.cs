using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.Repositories
{
    public class AuthorRepository
    {
        private IMapper _mapper;
        public AuthorRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            return _mapper.Map<List<AuthorDto>>(DataProvider.Authors);
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            return _mapper.Map<AuthorDetailDto>(DataProvider.Authors.Where(a => a.Id == id).SingleOrDefault());
        }

        private List<NewsItem> GetNewsItemsByAuthorId(int id)
        {
            var newsItems = (from news in DataProvider.NewsItems
                                 join newsauthors in DataProvider.NewsItemAuthors on news.Id equals newsauthors.NewsItemId
                                 join authors in DataProvider.Authors on newsauthors.AuthorId equals authors.Id
                                 where authors.Id == id
                                 select news).ToList();
            return newsItems;
        }

        public List<NewsItemDto> GetNewsItemsByAuthor(int id)
        {
            List<NewsItemDto> NewsItemsDto = new List<NewsItemDto>();
            var newsItems = GetNewsItemsByAuthorId(id);
            foreach (var item in newsItems)
            {
                var newsItemDto = _mapper.Map<NewsItemDto>(item);
                NewsItemsDto.Add(newsItemDto);    
            }
            return NewsItemsDto;
        }

        public void LinkNewsItemToAuthorById(int aid, int nid)
        {
            var link = new NewsItemAuthors
            {
                AuthorId = aid,
                NewsItemId = nid
            };
            DataProvider.NewsItemAuthors.Add(link);
        }

        public AuthorDto CreateAuthor(AuthorInputModel author)
        {
            var nextId = DataProvider.Authors.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            var entity = new Author
            {
                Id = nextId,
                Name = author.Name,
                ProfileImgSource = author.ProfileImgSource,
                Bio = author.Bio,
                ModifiedBy = "TechnicalRadiationAdmin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            DataProvider.Authors.Add(entity);
            return new AuthorDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; /* Throw some exception */}

            // Update properties
            entity.Name = author.Name;
            entity.ProfileImgSource = author.ProfileImgSource;
            entity.Bio = author.Bio;
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "TechnicalRadiationAdmin";
        }

        public void DeleteAuthorById(int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(entity == null) { return; /* Throw some exception */}
            DataProvider.Authors.Remove(entity);
        }

    }
}