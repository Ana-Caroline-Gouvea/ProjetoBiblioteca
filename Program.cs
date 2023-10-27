using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Carol
    (options => options.UseSqlServer("Data Source=SB-1490638\\SQLSENAI;Initial Catalog = ProjetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Isa
    (options => options.UseSqlServer("Data Source=SB-1490635\\SQLSENAI;Initial Catalog = ProjetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Melina
    (options => options.UseSqlServer("Data Source=SB-1490650\\SQLSENAI;Initial Catalog = ProjetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"));*/
/*.Services.AddDbContext<Contexto> //Melina
    (options => options.UseSqlServer("Data Source=SB-1490650\\SQLSENAI;Initial Catalog = ProjetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Vitor
    (options => options.UseSqlServer("Data Source=SB-1490654\\SQLSENAI;Initial Catalog = ProjetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"));*/

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
