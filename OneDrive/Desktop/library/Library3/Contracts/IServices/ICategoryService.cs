using Library3.Dto;
namespace Library3.Contracts.IServices
{
    public interface ICategoryService
    {
        public void CreateCategory(string name);
        public List<CategoryDto> GetCategories();
    }
}
