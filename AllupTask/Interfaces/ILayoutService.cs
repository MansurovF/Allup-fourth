using AllupTask.Models;
using AllupTask.ViewModels.BasketViewModels;

namespace AllupTask.Interfaces
{
    public interface ILayoutService
    {
        Task<IDictionary<string,string>> GetSettings();
        Task<IEnumerable<Category>> GetCategories();

        Task<List<BasketVM>> GetBaskets();
    }
}
