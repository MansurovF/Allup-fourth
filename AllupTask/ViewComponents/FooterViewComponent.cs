using AllupTask.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace AllupTask.ViewComponents
{
    public class FooterViewComponent :ViewComponent
    {

        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(IDictionary<string, string> settings) 
        {
            //IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return View(settings);
        }
    }
}
