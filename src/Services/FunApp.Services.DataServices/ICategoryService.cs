using System.Collections.Generic;
using System.Text;

namespace FunApp.Services.DataServices
{
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAllCategories();
        Task<bool> IsValidCategoryIdAsync(int jokeCategoriId);
    }
}
