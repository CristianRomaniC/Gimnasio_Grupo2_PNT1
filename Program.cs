// --- PASO 1 (NUEVO): Agregar los 'using' ---
using Microsoft.EntityFrameworkCore;
using GimnasioGrupo2.Data;

var builder = WebApplication.CreateBuilder(args);

// --- PASO 2 (NUEVO): Obtener la cadena de conexión ---
var connectionString = builder.Configuration.GetConnectionString("GimnasioDBConnection")
                     ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'GimnasioDBConnection'.");

// --- PASO 3 (NUEVO): REGISTRAR EL SERVICIO DbContext ---
// Esta es la línea que soluciona el error
//
builder.Services.AddDbContext<GimnasioContext>(options =>
    options.UseSqlServer(connectionString)
);
// --- FIN DE LOS PASOS NUEVOS ---

// Elimina la segunda declaración de 'builder' para evitar el error CS0128
// var builder = WebApplication.CreateBuilder(args); <-- Esta línea se elimina

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
