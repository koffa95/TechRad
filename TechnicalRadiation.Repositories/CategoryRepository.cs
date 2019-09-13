using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepository
    {
        private IMapper _mapper;

        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _mapper.Map<List<CategoryDto>>(DataProvider.Categories);
        }

        public void LinkNewsItemToCategoryById(int cid, int nid)
        {
            var temp = new NewsItemCategories
            {
                CategoryId = cid,
                NewsItemId = nid
            };
            DataProvider.NewsItemCategories.Add(temp);
        }

        public int GetNumberOfNewsItemsByCategoryId(int id)
        {
            int NumNewsItems = (from news in DataProvider.NewsItems
                                 join newsCat in DataProvider.NewsItemCategories on news.Id equals newsCat.NewsItemId
                                 join cat in DataProvider.Categories on newsCat.CategoryId equals cat.Id
                                 where cat.Id == id
                                 select news).Count();
            return NumNewsItems;
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
            entity.Name = category.Name;
            entity.Slug = category.Name.ToLower().Replace(' ', '-');
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "TechnicalRadiationAdmin";
        }

        public void DeleteCategoryById(int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if (entity == null) 
            { 
                return;
            }
            DataProvider.Categories.Remove(entity);
        }
    }
}