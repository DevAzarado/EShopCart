using EShopCart.Models.ViewModels;
using EShopCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopCart.Infrastructure.Components
{
    public class PromotionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var resultado = GetItemsAsync();
            return View(resultado);
        }

        private List<Promotions> GetItemsAsync()
        {
            List<Promotions> listPromotions = new List<Promotions>
            {
                new Promotions { Id=11, Name = "Code Branca", Description="Code Branca" , Price=2.99M},
                new Promotions { Id=12, Name = "Code Preto",Description="Blusa Code Preto", Price=12.99M },
                new Promotions { Id=13, Name = "Code",Description="Blusa Code", Price=7.99M },
                new Promotions { Id=14, Name = "Code Salmon", Description="Blusa Code Salmon", Price=6.99M }

            };

            return listPromotions;
        }



    }
}
