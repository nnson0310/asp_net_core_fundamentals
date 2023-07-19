using BethanysPieShop.ModelRepository;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbConnection"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();

app.UseStaticFiles();

app.UseSession();

app.MapDefaultControllerRoute();

//app.MapControllers();

app.UseRouting();

app.MapRazorPages();

app.MapBlazorHub();

app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

DbSeed.Seed(app);

app.Run();
