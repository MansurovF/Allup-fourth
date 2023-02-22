using AllupTask.Models;
using AllupTask.ViewModels.BasketViewModels;

namespace AllupTask.ViewModels.HeaderViewComponent
{
    public class HeaderVM
    {
        public IDictionary<string,string>  Settings{ get; set; }
        public List<BasketVM> BasketVMs{ get; set; }

        public IEnumerable<Category> categories { get; set; }
    }
}
