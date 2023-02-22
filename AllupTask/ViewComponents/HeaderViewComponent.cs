using AllupTask.DataAccessLayer;
using AllupTask.Models;
using AllupTask.ViewModels.BasketViewModels;
using AllupTask.ViewModels.HeaderViewComponent;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace AllupTask.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {

        private readonly AppDbContext _context;

        public HeaderViewComponent (AppDbContext context)
        {
            _context = context; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

            //string cookie = HttpContext.Request.Cookies["basket"];
            //List<BasketVM> basketVMs = null;

            //if (!string.IsNullOrWhiteSpace(cookie)) 
            //{
            //    basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
            //    foreach (BasketVM basketVM in basketVMs)
            //    {
            //        Product product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == basketVM.Id);

            //        if (product != null)
            //        {
            //            basketVM.Title = product.Title;
            //            basketVM.Price = product.DiscountPrice > 0 ? product.DiscountPrice : product.Price;
            //            basketVM.Image = product.MainImage;
            //            basketVM.ExTax = product.ExTax;
            //        }
            //    }
            //}
            //else
            //{
            //    basketVMs = new List<BasketVM>();
            //}
            //HeaderVM headerVM = new HeaderVM
            //{
            //    Settings = settings,
            //    BasketVMs=basketVMs,
            //    categories= await _context.Categories.Include(c=>c.Children.Where(a=>a.IsDeleted == false)).Where(c=>c.IsDeleted == false && c.IsMain).ToList(),
            //};

            return View(headerVM);
        }
    }
}
