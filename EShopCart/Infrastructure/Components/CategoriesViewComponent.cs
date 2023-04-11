using EShopCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopCart.Infrastructure.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public CategoriesViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GetItemsAsync());
        }

        private async Task<List<Category>> GetItemsAsync()
        {
            return await _context!.Categories!.ToListAsync();
        }
    }
}
