using BLL.Services;
using DAL.Context;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Repositories and services injected into the container

builder.Services.AddTransient<ICategoryRepository , CategoryRepository>();
builder.Services.AddTransient<IMenuRepository , MenuRepository>();
builder.Services.AddTransient<IOrderRepository , OrderRepository>();
builder.Services.AddTransient<IProductRepository , ProductRepository>();
builder.Services.AddTransient<AdminService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<MenuService>();
builder.Services.AddTransient<ProductService>();



// Add services to the container.
builder.Services.AddControllersWithViews();



//ConStr adını herkes kendi adıyla değiştirmesi yeterli
builder.Services.AddDbContext<AppDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Sude")));

builder.Services.AddIdentity<AppUser , IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");

builder.Services.Configure<IdentityOptions>(opt =>
{
	opt.User.RequireUniqueEmail = true;
});

var app = builder.Build();






// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
