using AllupTask.DataAccessLayer;
using AllupTask.Interfaces;
using AllupTask.Models;
using AllupTask.ViewModels.BasketViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AllupTask.Services
{
    public class LayoutService :ILayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BasketVM>> GetBaskets()
        {
            string cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

            if (string.IsNullOrWhiteSpace(cookie))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
                foreach ( BasketVM basketVM in basketVMs)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == basketVM.Id);

                    if (product!= null)
                    {
                        basketVM.Title = product.Title;
                        basketVM.Price = product.DiscountPrice > 0 ? product.DiscountPrice : product.Price;
                        basketVM.Image = product.MainImage;
                        basketVM.ExTax = product.ExTax;
                    }
                }
                return basketVMs;
            }
            return new List<BasketVM>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories
                .Include(c=>c.Children.Where(c=>c.IsDeleted == false))
                .Where(c=>c.IsDeleted == false && c.IsMain).ToListAsync();
        }

        public async Task<IDictionary<string, string>> GetSettings()
        {
            IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return settings;
        }
        


    }
}
