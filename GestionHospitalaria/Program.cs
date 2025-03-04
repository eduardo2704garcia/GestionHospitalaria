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
builder.Services.AddScoped<TratamientosDAL>();
builder.Services.AddScoped<TratamientosBL>();
builder.Services.AddScoped<EspecialidadesDAL>();
builder.Services.AddScoped<EspecialidadesBL>();
builder.Services.AddScoped<MedicosDAL>();
builder.Services.AddScoped<MedicosBL>();
builder.Services.AddScoped<CitasDAL>();
builder.Services.AddScoped<CitasBL>();
builder.Services.AddScoped<FacturacionDAL>();
builder.Services.AddScoped<FacturacionBL>();
builder.Services.AddScoped<AdministradorDAL>();
builder.Services.AddScoped<AdministradorBL>();
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

