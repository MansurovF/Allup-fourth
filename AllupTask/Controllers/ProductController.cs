﻿using AllupTask.DataAccessLayer;
using AllupTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllupTask.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Modal( int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products.Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p =>p.IsDeleted == false && p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return PartialView("_ModalPartial", product);
             
        }
        public async Task <IActionResult> Search (string search,int? categoryId)
        {

            IEnumerable<Product> products = await _context.Products
                .Where(p =>
                p.IsDeleted == false &&
                (categoryId != null &&
                 categoryId > 0 &&
                _context.Categories.Any(c => c.IsDeleted == false && c.Id == categoryId) ? p.CategoryId == categoryId : true) &&
                (p.Title.ToLower().Contains(search.Trim().ToLower()) ||
                      p.Brand.Name.ToLower().Contains(search.Trim().ToLower()) ||
                      p.Category.Name.ToLower().Contains(search.Trim().ToLower()))
                      ).OrderByDescending(p=>p.Id).Take(5).ToListAsync();
            return PartialView("_SearchPartial", products);


             

            //if (categoryId != null && categoryId > 0)
            //{
            //    if (!await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Id == categoryId))
            //    {
            //        return BadRequest();
            //    }
            //    IEnumerable<Product> products = await _context.Products
            //        .Where(
            //            p => p.IsDeleted == false && p.CategoryId == categoryId &&
            //           (p.Title.ToLower().Contains(search.Trim().Tolower()) ||
            //           p.Brand.Name.ToLower().Contains(search.Trim().Tolower())))
            //          .ToListAsync();

            //    return PartialView("_SearchPartial",products);
            //}


        }
    }
}
