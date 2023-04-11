using EShopCart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShopCart.Infrastructure
{

    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public DbInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
                else
                {

                }

                if (_context.Products.Count() == 0 && _context.Categories.Count() == 0)
                {

                    _context.Database.Migrate();
                    Category camisa = new Category { Name = "Camisa", Slug = "camisa" };
                    Category blusa = new Category { Name = "Blusa", Slug = "blusa" };


                    _context.Products.AddRange(
                    new Product
                    {
                        Name = "Code Preta",
                        Slug = "code Preta",
                        Description = "Camisa Code Preta",
                        Image = "dfb823e5-1fdb-4772-875d-318d0ff46fd5_PretaDogt.jpg",
                        Price = 3.99M,
                        Category = camisa
                    },
                     new Product
                     {
                         Name = "Code Branca",
                         Slug = "code branca",
                         Description = "Camisa Code Branca",
                         Image = "1cbad909-c74b-419a-9b49-b38b80dc104c_800_Caveira.jpg",
                         Price = 4.99M,
                         Category = camisa
                     },
                     new Product
                     {
                         Name = "Code Preta",
                         Slug = "code preta",
                         Description = "Bulsa Code Preta",
                         Image = "7fe82c09-3c3d-46dc-95e9-15f1c88d400c_Preta.jpg",
                         Price = 5.99M,
                         Category = blusa
                     } ,
                     new Product
                     {
                         Name = "Code Azul",
                         Slug = "Code azul",
                         Description = "Bulsa Code Azul",
                         Image = "9a1bff16-7b0a-4cf8-b31c-fececf49abaa_Azul.jpg",
                         Price = 6.99M,
                         Category = blusa
                     },
                     new Product
                     {
                         Name = "Code Laranja",
                         Slug = "code laranja",
                         Description = "Bulsa Code Laranja",
                         Image = "18ef4175-b8e7-47e3-97c0-7d159d192d92_Laranja.jpg",
                         Price = 7.99M,
                         Category = blusa
                     }

                     );
                    _context.SaveChanges();
                }
                else
                {

                }


            }
            catch( Exception ex)
            {

            }



            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync( new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Employee")).GetAwaiter().GetResult();

                _userManager.CreateAsync(new AppUser
                {
                    UserName = "andersonzion@hotmail.com",
                    Email = "andersonzion@hotmail.com",
                    PhoneNumber = "112233344"
                }, "Admin123*").GetAwaiter().GetResult();

                    AppUser user  = _context.AppUsers.FirstOrDefault( u => u.Email == "andersonzion@hotmail.com");

                _userManager.AddToRoleAsync( user,"Admin").GetAwaiter().GetResult();
            }
            else
            {

            }

            return;

        }
    }
}
