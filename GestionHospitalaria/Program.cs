using CapaDatos;
using CapaNegocio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext usando la cadena de conexión correcta
builder.Services.AddDbContext<HospitalDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDBConnection")));

// Registrar las dependencias de tus capas
builder.Services.AddScoped<PacientesDAL>();
builder.Services.AddScoped<PacientesBL>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de middleware
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

