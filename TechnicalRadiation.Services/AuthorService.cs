using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using TechnicalRadiation.Models.Extensions;
using System.Linq;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepository _authorRepo;

        public AuthorService(IMapper mapper)
        {
            _authorRepo = new AuthorRepository(mapper);
        }

        private AuthorDto AddAuthorDtoLinks(AuthorDto author)
        {
            author.Links.AddReference("edit", $"api/authors/{author.Id}");
            author.Links.AddReference("delete", $"api/authors/{author.Id}");
            author.Links.AddReference("self", $"api/authors");
            author.Links.AddReference("newsItems", $"api/authors/{author.Id}/newsItems");
            author.Links.AddListReference("newsItemsDetailed", _authorRepo.GetNewsItemsByAuthor(author.Id)
                .Select(n => new { href = $"api/{n.Id}" }));
            return author;
        }

        private AuthorDetailDto AddAuthorDetailDtoLinks(AuthorDetailDto author)
        {
            author.Links.AddReference("edit", $"api/authors/{author.Id}");
            author.Links.AddReference("delete", $"api/authors/{author.Id}");
            author.Links.AddReference("self", $"api/authors");
            author.Links.AddReference("newsItems", $"api/authors/{author.Id}/newsItems");
            author.Links.AddListReference("newsItemsDetailed", _authorRepo.GetNewsItemsByAuthor(author.Id)
                .Select(n => new { href = $"api/{n.Id}" }));
            return author;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepo.GetAllAuthors();
            foreach (var a in authors)
            {
                AddAuthorDtoLinks(a);
            }
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            var author = _authorRepo.GetAuthorById(id);
            AddAuthorDetailDtoLinks(author);
            return author;
        }

        public void LinkNewsItemToAuthorById(int cid, int nid)
        {
            _authorRepo.LinkNewsItemToAuthorById(cid, nid);
        }


        public List<NewsItemDto> GetNewsItemsByAuthor(int id)
        {
            var newsItems = _authorRepo.GetNewsItemsByAuthor(id);
            return newsItems;
        }

        public AuthorDto CreateAuthor(AuthorInputModel author)
        {
            return _authorRepo.CreateAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            _authorRepo.UpdateAuthorById(author, id);
        }

        public void DeleteAuthorById(int id)
        {
            _authorRepo.DeleteAuthorById(id);
        }
    }
}