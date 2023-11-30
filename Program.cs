using ArtHub.Services;
using ArtHub.Services.ServicesImpl;
using Microsoft.EntityFrameworkCore;
using ArtHub.Models;


var builder = WebApplication.CreateBuilder(args);
//Register db context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IUserService and its implementation
builder.Services.AddSingleton<UserService, UserServiceImpl>();
builder.Services.AddSingleton<ArtworkService, ArtworkServiceImpl>();
builder.Services.AddSingleton<CategoryService, CategoryServiceImpl>();
builder.Services.AddSingleton<BidService, BidServiceImpl>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
