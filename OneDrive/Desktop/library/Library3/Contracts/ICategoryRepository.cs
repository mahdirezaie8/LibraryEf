using Library3.Dto;
using Library3.ntts;
namespace Library3.Contracts
{
    public interface ICategoryRepository
    {
        int Create(Category category);
        void Update(Category category);
        List<CategoryDto> GetAll();
        Category GetById(int id);
        void Delete(int id);
    }
}
