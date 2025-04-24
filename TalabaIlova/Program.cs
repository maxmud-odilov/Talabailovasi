using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TalabaIlova.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Konfiguratsiyani yuklash
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()) // Fayl joylashuvi
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();

// EF Core kontekstni ulash
builder.Services.AddDbContext<TalabaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TalabaConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Talabalar}/{action=Index}/{id?}");

app.Run();
