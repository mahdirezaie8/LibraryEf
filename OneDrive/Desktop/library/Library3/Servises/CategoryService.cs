using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;

namespace Library3.Servises
{
    public class CategoryService: ICategoryService
    {
        ICategoryRepository repository =new CategoryRepository();
        public void CreateCategory(string name)
        {
            var oldcategory=repository.GetAll().FirstOrDefault(x=>x.Name.ToLower()==name.ToLower());
            if (oldcategory!=null)
            {
                throw new Exception("There is a category whith this name");
            }
            else if (string.IsNullOrEmpty(name))
            {
                throw new Exception("name is null");
            }
            else
            {
                Category category = new Category()
                {
                    Name = name,
                };
                repository.Create(category);
            }
        }
        public List<CategoryDto> GetCategories()
        {
            var categories = repository.GetAll();
            return categories;
        }
    }
}
