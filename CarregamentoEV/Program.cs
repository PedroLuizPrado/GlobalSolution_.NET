using CarregamentoEV.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a ConnectionString
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar controllers com views
builder.Services.AddControllersWithViews();

// Adicionar serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CarregamentoEV API",
        Version = "v1",
        Description = "API para gerenciamento de estações de carregamento de veículos elétricos",
        Contact = new OpenApiContact
        {
            Name = "Pedro Luiz Prado",
            Email = "pedro.luiz@example.com"
        }
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configurar o middleware do Swagger para que funcione sempre
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarregamentoEV API v1");
    c.RoutePrefix = string.Empty; // Faz o Swagger abrir na raiz (exemplo: https://localhost:7179/)
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
