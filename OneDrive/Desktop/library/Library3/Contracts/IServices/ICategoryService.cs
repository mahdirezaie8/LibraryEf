using Library3.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts.IServices
{
    public interface ICategoryService
    {
        public void CreateCategory(string name);
        public List<CategoryDto> GetCategories();
    }
}
