using ArtHub.Services;
using ArtHub.Services.ServicesImpl;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IUserService and its implementation
builder.Services.AddSingleton<UserService, UserServiceImpl>();
builder.Services.AddSingleton<ArtworkService, ArtworkServiceImpl>();
builder.Services.AddSingleton<CategoryService, CategoryServiceImpl>();
builder.Services.AddSingleton<BidService, BidServiceImpl>();
builder.Services.AddSingleton<UserPreferenceService, UserPreferenceServiceImpl>();
builder.Services.AddSingleton<TransactionService, TransactionServiceImpl>();


// Swagger Config
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArtHub APIs", Version = "v1" });
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

app.UseAuthorization();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArtHub APIs");
    c.RoutePrefix = "swagger";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
