using Microsoft.AspNetCore.Cors.Infrastructure;
using SeisTec.Services;

var builder = WebApplication.CreateBuilder(args);

// Registro de servicios
builder.Services.AddScoped<LlamadasService>();

// Otros registros de servicios
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del middleware
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();