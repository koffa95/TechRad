
using System;
using System.Collections.Generic;
using Models.Entities;
public static class DataProvider {
    private static readonly string _adminName = "Admin";
    public static List<NewsItem> NewsItems = new List<NewsItem>()
    {
        new NewsItem { Id = 1, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(2019, 1, 1), ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = new DateTime() },
        new NewsItem { Id = 2, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(2019, 1, 2), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 3, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = DateTime.Now, ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 4, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 5, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 6, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 7, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 8, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 9, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 10, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 11, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 12, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 13, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 14, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 15, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 16, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 17, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 18, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 19, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 20, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 21, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 22, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 23, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 24, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 25, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 26, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 27, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 28, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 29, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
        new NewsItem { Id = 30, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "Admin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() }
    };

    public static List<Category> Categories = new List<Category>()
    {
        new Category { Id = 1, Name = "Business", Slug = "business", ModifiedBy = _adminName, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Category { Id = 2, Name = "Sports", Slug = "sports", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Category { Id = 3, Name = "Health", Slug = "health", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Category { Id = 4, Name = "Gadgets", Slug = "gadgets", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
    };

    public static List<Author> Authors = new List<Author>()
    {
        new Author { Id = 1, Name = "Brandon Sanderson", ProfileImgSource = "", Bio = "", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Author { Id = 2, Name = "Stephen King", ProfileImgSource = "", Bio = "", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Author { Id = 3, Name = "Patrick Rothfuss", ProfileImgSource = "", Bio = "", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Author { Id = 4, Name = "Terry Pratchett", ProfileImgSource = "", Bio = "", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
        new Author { Id = 5, Name = "Enid Blyton", ProfileImgSource = "", Bio = "", ModifiedBy = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }      
    };

    public static List<NewsItemCategories> NewsItemCategories = new List<NewsItemCategories>()
    {
        new NewsItemCategories { CategoryId = 1, NewsItemId = 1 },
        new NewsItemCategories { CategoryId = 1, NewsItemId = 2 },
        new NewsItemCategories { CategoryId = 2, NewsItemId = 3 },
        new NewsItemCategories { CategoryId = 2, NewsItemId = 4 },
        new NewsItemCategories { CategoryId = 2, NewsItemId = 5 },
        new NewsItemCategories { CategoryId = 3, NewsItemId = 28 },
    };

    public static List<NewsItemAuthors> NewsItemAuthors = new List<NewsItemAuthors>()
    {
        new NewsItemAuthors { AuthorId = 1, NewsItemId = 1 },
        new NewsItemAuthors { AuthorId = 1, NewsItemId = 2 },
        new NewsItemAuthors { AuthorId = 2, NewsItemId = 3 },
        new NewsItemAuthors { AuthorId = 2, NewsItemId = 4 },
        new NewsItemAuthors { AuthorId = 2, NewsItemId = 5 },
        new NewsItemAuthors { AuthorId = 3, NewsItemId = 28 },
    };
}