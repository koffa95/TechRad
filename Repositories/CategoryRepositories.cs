using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models;
using Models.DTO;
using Models.Entities;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepo
    {
        private IMapper _mapper;

        public CategoryRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _mapper.Map<List<CategoryDto>>(DataProvider.Categories);
        }

        public void LinkNewsItemToCategoryById(int cid, int nid)
        {
            var link = new NewsItemCategories
            {
                CategoryId = cid,
                NewsItemId = nid
            };
            DataProvider.NewsItemCategories.Add(link);
        }

        public int GetNumberOfNewsItemsByCategoryId(int id)
        {
            int NumberOfNewsItems = (from news in DataProvider.NewsItems
                                 join newscategories in DataProvider.NewsItemCategories on news.Id equals newscategories.NewsItemId
                                 join categories in DataProvider.Categories on newscategories.CategoryId equals categories.Id
                                 where categories.Id == id
                                 select news).Count();
            return NumberOfNewsItems;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            return _mapper.Map<CategoryDetailDto>(DataProvider.Categories.Where(c => c.Id == id).SingleOrDefault());
        }

        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            var nextId = DataProvider.Categories.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            
            var entity = new Category
            {
                Id = nextId,
                Name = category.Name,
                ModifiedBy = "TechnicalRadiationAdmin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var slug = entity.Name.ToLower().Replace(' ', '-');
            entity.Slug = slug;
            DataProvider.Categories.Add(entity);
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug
            };
        }
        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(n => n.Id == id);

            // Update properties
            entity.Name = category.Name;
            entity.Slug = category.Name.ToLower().Replace(' ', '-');
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "TechnicalRadiationAdmin";
        }

        public void DeleteCategoryById(int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if (entity == null) { return; /* Throw some exception */}
            DataProvider.Categories.Remove(entity);
        }
    }
}