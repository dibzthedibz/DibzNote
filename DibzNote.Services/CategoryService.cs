using DibzNote.Data;
using DibzNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibzNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Title = model.Title
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e =>
                            new CategoryListItem
                            {
                                CategoryId = e.CategoryId,
                                Title = e.Title
                            }
                            );
                return query.ToArray();
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == id);

                return new CategoryDetail
                {
                    CategoryId = entity.CategoryId,
                    Title = entity.Title,
                    Notes = entity.Notes
                    .Select(e => new NoteListItem()
                    {
                        NoteId = e.NoteId,
                        Title = e.Title,
                        CreatedUtc = e.CreatedUtc,
                        CategoryId = e.CategoryId
                    }).ToList()
                };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == model.CategoryId);

                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == categoryId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
