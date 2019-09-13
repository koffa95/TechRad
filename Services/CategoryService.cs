using System.Collections.Generic;
using AutoMapper;
using Models;
using Models.DTO;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.WebApi.Controllers
{
    public class CategoryService
    {
        private CategoryRepo _categoryRepo;

        public CategoryService(IMapper mapper)
        {
            _categoryRepo = new CategoryRepo(mapper);
        }

        public List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepo.GetAllCategories();
            foreach (var c in categories)
            {
                c.Links.AddReference("edit", $"api/categories/{c.Id}");
                c.Links.AddReference("self", $"api/categories/{c.Id}");
                c.Links.AddReference("delete", $"api/categories/{c.Id}");
            }
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);
            //category.NumberOfNewsItems = _categoryRepo.GetNumberOfNewsItemsByCategoryId(id);
            category.Links.AddReference("edit", $"api/categories/{category.Id}");
            category.Links.AddReference("self", $"api/categories/{category.Id}");
            category.Links.AddReference("delete", $"api/categories/{category.Id}");
            return category;
        }

        public void LinkNewsItemToCategoryById(int cid, int nid)
        {
            _categoryRepo.LinkNewsItemToCategoryById(cid, nid);
        }

        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            return _categoryRepo.CreateCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            _categoryRepo.UpdateCategoryById(category, id);
        }

        public void DeleteCategoryById(int id)
        {
            _categoryRepo.DeleteCategoryById(id);
        }
    }
}