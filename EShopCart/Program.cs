
using EShopCart.Infrastructure;
using EShopCart.Infrastructure.Culture;
using EShopCart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

CultureConfig.ConfigCulture();

builder.Services.AddDbContext<DataContext>( options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});


builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

// Add services to the container.
builder.Services.AddControllersWithViews();





var app = builder.Build();

app.UseSession();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

SeedDatabase();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Products",
    pattern: "/Products/{categorySlug?}",
    defaults: new { controller = "Products", action = "Index" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
//SeedData.SeedDatabase(context);


app.Run();


void SeedDatabase()
{
    using( var scope = app.Services.CreateScope())
    {
        var dbInitializar = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializar.Initialize();
    }
}


