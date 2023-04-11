using EShopCart.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopCart.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (context.Products.Count() == 0 && context.Categories.Count() ==0)
            {
                Category camisa = new Category { Name="Camisa", Slug="camisa"};
                Category blusa = new Category { Name = "Blusa", Slug = "blusa" };


                context.Products.AddRange( 
                new Product
                {
                    Name="Branca",
                    Slug="branca",
                    Description="Camisa Branca",
                    Image= "camisaBranca.jpg",
                    Price=11.99M,
                    Category = camisa
                },
                 new Product
                 {
                     Name = "Laranja",
                     Slug = "laranja",
                     Description = "Blusa Laranja",
                     Image = "camisaLaranja.jpg",
                     Price = 11.99M,
                     Category = blusa
                 } );

     

            }

            context.SaveChanges();
        }
    }
}
