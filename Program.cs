using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;
using R4G.App.Repositories;
using R4G.App.Repositories.Interfaces;
using R4G.App.Services;
using R4G.App.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        connectionString,
        sql => sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
    );
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddErrorDescriber<R4G.App.Identity.SpanishIdentityErrorDescriber>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ICarrerasRepository, CarrerasRepository>();
builder.Services.AddScoped<IEntrenamientosRepository, EntrenamientosRepository>();
builder.Services.AddScoped<IMejoresMarcasRepository, MejoresMarcasRepository>();
builder.Services.AddScoped<IProximasCarrerasRepository, ProximasCarrerasRepository>();

builder.Services.AddScoped<ICarrerasService, CarrerasService>();
builder.Services.AddScoped<IEntrenamientosService, EntrenamientosService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IEstadisticasService, EstadisticasService>();
builder.Services.AddScoped<IProximasCarrerasService, ProximasCarrerasService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
