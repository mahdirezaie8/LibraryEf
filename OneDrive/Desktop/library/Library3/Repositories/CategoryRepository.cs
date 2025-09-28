using Library3.Contracts;
using Library3.Dto;
using Library3.Infrastructure;
using Library3.ntts;
namespace Library3.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        AppDbContext _context = new AppDbContext();
        public int Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.ID;
        }

        public void Delete(int id)
        {
          var category = _context.Categories.FirstOrDefault(c => c.ID == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            else
                throw new Exception("category not found");
        }

        public List<CategoryDto> GetAll()
        {
            var categories=_context.Categories.Select(x=>new CategoryDto
            {
                Id = x.ID,
                Name = x.Name,
            }).ToList();
            return categories;
        }

        public Category GetById(int id)
        {
            var category= _context.Categories.FirstOrDefault(x=>x.ID == id);
            if (category != null)
            {
                return category;
            }
            else
                throw new Exception("category not found");
        }

        public void Update(Category category)
        {
            var oldcategory= _context.Categories.FirstOrDefault(x => x.ID == category.ID);
            if (oldcategory != null)
            {
                oldcategory.Name = category.Name;
                oldcategory.Books = category.Books;
            }
            _context.SaveChanges();
        }

    }
}
